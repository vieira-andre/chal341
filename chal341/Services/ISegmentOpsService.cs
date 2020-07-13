using chal341.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chal341.Services
{
    public interface ISegmentOpsService
    {
        Task AddExchangeFeeAsync(AddExchangeFeeRequest request);

        Task<GetExchangeFeeResponse> GetExchangeFeeAsync(GetExchangeFeeRequest request);

        Task<IEnumerable<GetExchangeFeeResponse>> GetAllExchangeFeesAsync();
    }
}
