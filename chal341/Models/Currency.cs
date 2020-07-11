namespace chal341.Models
{
    public class Currency
    {
        public Currency(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
