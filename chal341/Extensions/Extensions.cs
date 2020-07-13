using chal341.Models;
using System;
using System.Globalization;

namespace chal341.Extensions
{
    public static class Extensions
    {
        public static decimal ToDecimal(this string decimalAsString)
        {
            if (decimal.TryParse(decimalAsString, NumberStyles.AllowDecimalPoint, new CultureInfo(Variables.Locale), out decimal result))
                return result;
            else
                throw new FormatException("The string cannot be parsed to decimal. " +
                    $"If a decimal point was provided, it must be in accordance with the current culture info ({Variables.Locale}). " +
                    "Likewise, no thousands separator is allowed.");

        public static ClientSegment ParseFromString(this string segmentAsString)
        {
            if (Enum.TryParse(segmentAsString, out ClientSegment result) && !result.Equals(default))
                return result;
            else
                throw new ArgumentException($"The string cannot be parsed to a valid value of {nameof(ClientSegment)}.");
        }
    }
}
