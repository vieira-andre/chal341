using System.Text.Json.Serialization;

namespace chal341.Contracts
{
    public class ExchangeApiResponse
    {
        public Rates Rates { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
    }

    public class Rates
    {
        [JsonPropertyName("BRL")]
        public decimal BRL { get; set; }
    }

}
