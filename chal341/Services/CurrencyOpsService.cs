using chal341.Contracts;
using chal341.Helpers;
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
        private readonly IExchangeFeeRepository _exchangeFeeRepository;
        private readonly IMapper _map;
        private readonly IUtils _utils;

        public CurrencyOpsService(IExchangeFeeRepository exchangeFeeRepository, IMapper map, IUtils utils)
        {
            _exchangeFeeRepository = exchangeFeeRepository;
            _map = map;
            _utils = utils;
        }

        public async Task<GetPriceQuotationResponse> GetPriceQuotationAsync(GetPriceQuotationRequest request)
        {
            var exchangeRate = await GetExchangeRateAsync(request.Code);

            var document = _map.ToDocumentModel(request);
            var responseFromDb = await _exchangeFeeRepository.GetExchangeFeeAsync(document);

            var exchangeFee = _map.ToContract(responseFromDb);

            if (exchangeFee is null)
                return default;

            var response = CalculatePriceQuotation(exchangeRate, request.Amount.ToInvariantDecimal(), exchangeFee);

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

            string requestUri = string.Concat(Variables.ExchangeApiUrl, path);

            var apiResponseAsString = await _utils.ExecuteHttpRequestAsync(HttpMethod.Get, requestUri);

            ExchangeApiResponse apiResponse = JsonSerializer.Deserialize<ExchangeApiResponse>(apiResponseAsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return apiResponse.Rates.BRL;
        }

        private GetPriceQuotationResponse CalculatePriceQuotation(ExchangeRate exchangeRate, decimal foreignCurrencyAmount, GetExchangeFeeResponse exchangeFee)
        {
            decimal price = foreignCurrencyAmount * exchangeRate.Rate * (1 + (exchangeFee.FeeCharged / 100));

            return new GetPriceQuotationResponse
            {
                Price = string.Concat(price.ToInvariantString(), " ", exchangeRate.CurrencyPair.quoteCurrency.Code),
                Amount = string.Concat(foreignCurrencyAmount.ToInvariantString(), " ", exchangeRate.CurrencyPair.baseCurrency.Code),
                Segment = exchangeFee.Segment
            };
        }
    }
}
