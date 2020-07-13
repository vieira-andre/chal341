using chal341.Models;

namespace chal341.Contracts
{
    public class AddExchangeFeeRequest
    {
        public ClientSegment Segment { get; set; }

        public string Fee { get; set; }
    }
}
