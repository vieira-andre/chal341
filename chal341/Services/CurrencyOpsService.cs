using chal341.Contracts;
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
            var exchangeRate = await GetExchangeRate(request.Code);

            return default;
        }

        private async Task<ExchangeRate> GetExchangeRate(string baseCurrencyCode)
        {
            decimal rate = await RetrieveExchangeRateFromApi(baseCurrencyCode);

            return new ExchangeRate(baseCurrencyCode, Variables.HomeCurrency, rate);
        }

        private async Task<decimal> RetrieveExchangeRateFromApi(string baseCurrencyCode)
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
    }
}
