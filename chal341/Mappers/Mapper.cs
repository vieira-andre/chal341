using chal341.Contracts;
using chal341.Extensions;
using chal341.Models.Data;

namespace chal341.Mappers
{
    public class Mapper : IMapper
    {
        public ExchangeFeeDb ToExchangeFeeDbModel(SetExchangeFeeRequest request)
        {
            return new ExchangeFeeDb
            {
                ClientSegment = request.Segment.ToString(),
                FeeCharged = request.Fee.ToDecimal()
            };
        }
    }
}
