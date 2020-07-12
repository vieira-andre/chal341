using System;
using System.Globalization;

namespace chal341.Extensions
{
    public static class Extensions
    {
        public static decimal ToDecimal(this string decimalAsString)
        {
            if (decimal.TryParse(decimalAsString, NumberStyles.AllowDecimalPoint, new CultureInfo("pt-BR"), out decimal result))
                return result;
            else
                throw new FormatException("The string cannot be parsed to decimal. " +
                    "If a decimal point was provided, it must be in accordance with the current culture info. " +
                    "Likewise, no thousands separator is allowed.");
        }
    }
}
