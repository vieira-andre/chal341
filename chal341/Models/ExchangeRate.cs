namespace chal341.Models
{
    public class ExchangeRate
    {
        private (Currency baseCurrency, Currency quoteCurrency) currencyPair;

        public ExchangeRate(string foreignCurrency, string homeCurrency, decimal rate)
        {
            currencyPair.baseCurrency = new Currency(foreignCurrency);
            currencyPair.quoteCurrency = new Currency(homeCurrency);
            Rate = rate;
        }

        public (Currency baseCurrency, Currency quoteCurrency) CurrencyPair { get => currencyPair; private set => currencyPair = value; }
        public decimal Rate { get; private set; }
    }
}
