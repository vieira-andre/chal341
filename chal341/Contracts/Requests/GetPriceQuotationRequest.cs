using chal341.Models;

namespace chal341.Contracts
{
    public class GetPriceQuotationRequest
    {
        private string code;

        /// <summary>
        /// The code of the base currency for the price quotation — i.e., the foreign currency.
        /// </summary>
        public string Code { get => code; set => code = value.ToUpper(); }

        /// <summary>
        /// The amount of foreign currency intended to be bought.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// The client segment of which an exchange fee will be applied for the price quotation calculation.
        /// </summary>
        public ClientSegment Segment { get; set; }
    }
}
