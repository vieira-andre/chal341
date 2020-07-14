using chal341.Models;

namespace chal341.Contracts
{
    public class AddExchangeFeeRequest
    {
        /// <summary>
        /// The customer segment to which an exchange fee is intended to be set.
        /// </summary>
        public CustomerSegment Segment { get; set; }

        /// <summary>
        /// The exchange fee to be associated with the customer segment.
        /// </summary>
        public string Fee { get; set; }
    }
}
