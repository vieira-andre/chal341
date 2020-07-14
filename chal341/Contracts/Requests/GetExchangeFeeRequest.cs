using chal341.Models;

namespace chal341.Contracts
{
    public class GetExchangeFeeRequest
    {
        /// <summary>
        /// The customer segment from which the exchange fee is desired.
        /// </summary>
        public CustomerSegment Segment { get; set; }
    }
}
