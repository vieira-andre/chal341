namespace chal341.Contracts
{
    public class GetExchangeRateRequest
    {
        private string code;

        /// <summary>
        /// The code of the base currency for the exchange rate.
        /// </summary>
        public string Code { get => code; set => code = value.ToUpper(); }
    }
}
