using System.Text.Json.Serialization;

namespace chal341.Contracts
{
    public class GetExchangeRateResponse
    {
        public string CurrencyPair { get => string.Concat(BaseCurrencyCode, '/', QuoteCurrencyCode); }

        [JsonIgnore]
        public string BaseCurrencyCode { get; set; }

        [JsonIgnore]
        public string QuoteCurrencyCode { get; set; }

        public decimal Rate { get; set; }
    }
}
