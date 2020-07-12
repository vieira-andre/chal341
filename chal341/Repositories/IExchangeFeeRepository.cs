using chal341.Models;
using chal341.Models.Data;
using System.Threading.Tasks;

namespace chal341.Repositories
{
    public interface IExchangeFeeRepository
    {
        Task AddExchangeFeeAsync(ExchangeFeeDb exchangeFeeDb);

        Task<ExchangeFeeDb> GetExchangeFeeAsync(ClientSegment segment);
    }
}
