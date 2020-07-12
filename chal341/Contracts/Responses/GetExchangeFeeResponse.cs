using chal341.Models;

namespace chal341.Contracts
{
    public class GetExchangeFeeResponse
    {
        public ClientSegment Segment { get; set; }

        public decimal FeeCharged { get; set; }
    }
}
