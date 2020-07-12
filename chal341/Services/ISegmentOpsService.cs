﻿using chal341.Contracts;
using chal341.Models;
using System.Threading.Tasks;

namespace chal341.Services
{
    public interface ISegmentOpsService
    {
        Task AddExchangeFeeAsync(SetExchangeFeeRequest request);

        Task<GetExchangeFeeResponse> GetExchangeFeeDbAsync(ClientSegment segment);
    }
}