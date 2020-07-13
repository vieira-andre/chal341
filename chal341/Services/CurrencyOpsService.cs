using chal341.Contracts;
using chal341.Extensions;
using chal341.Mappers;
using chal341.Models;
using chal341.Repositories;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace chal341.Services
{
    public class CurrencyOpsService : ICurrencyOpsService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IExchangeFeeRepository _exchangeFeeRepository;
        private readonly IMapper _map;

        public CurrencyOpsService(IHttpClientFactory clientFactory, IExchangeFeeRepository exchangeFeeRepository, IMapper map)
        {
            _clientFactory = clientFactory;
            _exchangeFeeRepository = exchangeFeeRepository;
            _map = map;
        }

        public async Task<GetPriceQuotationResponse> GetPriceQuotationAsync(GetPriceQuotationRequest request)
        {
            var exchangeRate = await GetExchangeRateAsync(request.Code);

            var document = _map.ToDocumentModel(request);
            var responseFromDb = await _exchangeFeeRepository.GetExchangeFeeAsync(document);

            var exchangeFee = _map.ToContract(responseFromDb);

            if (exchangeFee is null)
                return default;

            var response = CalculatePriceQuotation(exchangeRate, request.Units, exchangeFee);

            return response;
        }

        public async Task<GetExchangeRateResponse> GetExchangeRateAsync(GetExchangeRateRequest request)
        {
            decimal rate = await RetrieveExchangeRateFromApiAsync(request.Code);

            var response = new GetExchangeRateResponse {
                BaseCurrencyCode = request.Code,
                QuoteCurrencyCode = Variables.HomeCurrency,
                Rate = rate
            };

            return response;
        }

        private async Task<ExchangeRate> GetExchangeRateAsync(string baseCurrencyCode)
        {
            decimal rate = await RetrieveExchangeRateFromApiAsync(baseCurrencyCode);

            return new ExchangeRate(baseCurrencyCode, Variables.HomeCurrency, rate);
        }

        private async Task<decimal> RetrieveExchangeRateFromApiAsync(string baseCurrencyCode)
        {
            string path = string.Format(Variables.ExchangeApiPath, baseCurrencyCode, Variables.HomeCurrency);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, string.Concat(Variables.ExchangeApiUrl, path));

            var httpClient = _clientFactory.CreateClient();

            var httpResponse = await httpClient.SendAsync(httpRequest);

            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            ExchangeApiResponse apiResponse = JsonSerializer.Deserialize<ExchangeApiResponse>(responseAsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return apiResponse.Rates.BRL;
        }

        private GetPriceQuotationResponse CalculatePriceQuotation(ExchangeRate exchangeRate, int foreignCurrencyUnits, GetExchangeFeeResponse exchangeFee)
        {
            decimal price = foreignCurrencyUnits * exchangeRate.Rate * (1 + (exchangeFee.FeeCharged / 100));

            return new GetPriceQuotationResponse
            {
                Price = string.Concat(price.ToInvariantString(), " ", exchangeRate.CurrencyPair.quoteCurrency.Code),
                Units = string.Concat(foreignCurrencyUnits, " ", exchangeRate.CurrencyPair.baseCurrency.Code),
                Segment = exchangeFee.Segment
            };
        }
    }
}
