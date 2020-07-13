using chal341.Models;

namespace chal341.Contracts
{
    public class GetPriceQuotationRequest
    {
        public string Code { get; set; }

        public int Units { get; set; }

        public ClientSegment Segment { get; set; }
    }
}
