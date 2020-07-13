namespace chal341.Contracts
{
    public class GetExchangeRateRequest
    {
        private string code;

        public string Code { get => code; set => code = value.ToUpper(); }
    }
}
