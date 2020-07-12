using chal341.Contracts;
using chal341.Models.Data;

namespace chal341.Mappers
{
    public class Mapper : IMapper
    {
        public GetExchangeFeeResponse ToGetExchangeFeeContract(ExchangeFeeDb exchangeFeeDb)
        {
            return new GetExchangeFeeResponse
            {
                Segment = exchangeFeeDb.Segment,
                FeeCharged = exchangeFeeDb.FeeCharged
            };
        }

        public ExchangeFeeDb ToExchangeFeeDbModel(SetExchangeFeeRequest setExchangeFeeRequest)
        {
            return new ExchangeFeeDb
            {
                Segment = setExchangeFeeRequest.Segment,
                FeeCharged = (decimal)setExchangeFeeRequest.Fee
            };
        }
    }
}
