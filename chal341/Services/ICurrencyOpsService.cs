using chal341.Contracts;
using System.Threading.Tasks;

namespace chal341.Services
{
    public interface ICurrencyOpsService
    {
        Task<GetPriceQuotationResponse> GetPriceQuotationAsync(GetPriceQuotationRequest request);
    }
}
