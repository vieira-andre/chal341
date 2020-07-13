using chal341.Models;

namespace chal341.Contracts
{
    public class GetPriceQuotationResponse
    {
        public string Price { get; set; }

        public string Units { get; set; }

        public ClientSegment Segment { get; set; }
    }
}
