using chal341.Contracts;
using chal341.Mappers;
using chal341.Repositories;
using System.Net.Http;
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

        public Task<GetPriceQuotationResponse> GetPriceQuotationAsync(GetPriceQuotationRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
