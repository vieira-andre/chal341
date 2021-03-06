﻿using chal341.Contracts;
using chal341.Mappers;
using chal341.Repositories;
using System.Collections.Generic;
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

            await _exchangeFeeRepository.SaveExchangeFeeAsync(exchangeFeeDb);
        }

        public async Task<GetExchangeFeeResponse> GetExchangeFeeAsync(GetExchangeFeeRequest request)
        {
            var document = _map.ToDocumentModel(request);

            var response = await _exchangeFeeRepository.GetExchangeFeeAsync(document);

            return _map.ToContract(response);
        }

        public async Task<IEnumerable<GetExchangeFeeResponse>> GetAllExchangeFeesAsync()
        {
            var response = await _exchangeFeeRepository.GetAllExchangeFeesAsync();

            return _map.ToContract(response);
        }
    }
}
