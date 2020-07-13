using chal341.Contracts;
using chal341.Models.Data;

namespace chal341.Mappers
{
    public interface IMapper
    {
        ExchangeFeeDb ToExchangeFeeDbModel(AddExchangeFeeRequest request);
    }
}
