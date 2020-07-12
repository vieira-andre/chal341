using chal341.Models;

namespace chal341.Contracts
{
    public class SetExchangeFeeRequest
    {
        public ClientSegment Segment { get; set; }

        public decimal? Fee { get; set; }
    }
}
