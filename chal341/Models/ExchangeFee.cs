namespace chal341.Models
{
    public class ExchangeFee : IExchangeFee
    {
        public ClientSegment Segment { get; private set; }

        public decimal FeeCharged { get; private set; }
    }
}
