using chal341.Models;

namespace chal341.Contracts
{
    public class AddExchangeFeeRequest
    {
        /// <summary>
        /// The client segment to which an exchange fee is intended to be set.
        /// </summary>
        public ClientSegment Segment { get; set; }

        /// <summary>
        /// The exchange fee to be associated with the client segment.
        /// </summary>
        public string Fee { get; set; }
    }
}
