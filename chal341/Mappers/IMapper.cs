using chal341.Contracts;
using chal341.Models.Data;

namespace chal341.Mappers
{
    public interface IMapper
    {
        GetExchangeFeeResponse ToGetExchangeFeeContract(ExchangeFeeDb exchangeFee);

        ExchangeFeeDb ToExchangeFeeDbModel(SetExchangeFeeRequest setExchangeFeeRequest);
    }
}
