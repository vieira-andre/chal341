using chal341.Contracts;
using chal341.Mappers;
using chal341.Models;
using chal341.Repositories;
using System;
using System.Threading.Tasks;

namespace chal341.Services
{
    public class SegmentOpsService : ISegmentOpsService
    {
        private readonly IExchangeFeeRepository _exchangeFeeRepository;
        private readonly IMapper _map;

        public SegmentOpsService(IExchangeFeeRepository exchangeFeeRepository, IMapper map)
        {
            _exchangeFeeRepository = exchangeFeeRepository;
            _map = map;
        }

        public async Task AddExchangeFeeAsync(AddExchangeFeeRequest request)
        {
            var exchangeFeeDb = _map.ToDocumentModel(request);

            await _exchangeFeeRepository.AddExchangeFeeAsync(exchangeFeeDb);
        }

        public Task<GetExchangeFeeResponse> GetExchangeFeeDbAsync(ClientSegment segment)
        {
            throw new NotImplementedException();
        }
    }
}
