using chal341.Models;

namespace chal341.Contracts
{
    public class GetPriceQuotationRequest
    {
        private string code;

        public string Code { get => code; set => code = value.ToUpper(); }

        public int Units { get; set; }

        public ClientSegment Segment { get; set; }
    }
}
