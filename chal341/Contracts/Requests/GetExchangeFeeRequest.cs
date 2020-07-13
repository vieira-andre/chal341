using chal341.Models;

namespace chal341.Contracts
{
    public class GetExchangeFeeRequest
    {
        /// <summary>
        /// The client segment from which the exchange fee is desired.
        /// </summary>
        public ClientSegment Segment { get; set; }
    }
}
