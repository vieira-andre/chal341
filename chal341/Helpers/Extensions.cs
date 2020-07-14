using chal341.Models;
using System;
using System.Globalization;

namespace chal341.Helpers
{
    public static class Extensions
    {
        public static ClientSegment ParseFromString(this string segmentAsString)
        {
            if (Enum.TryParse(segmentAsString, out ClientSegment result) && !result.Equals(default))
                return result;
            else
                throw new ArgumentException($"The string cannot be parsed to a valid value of {nameof(ClientSegment)}.");
        }

        public static decimal ToInvariantDecimal(this string decimalAsString)
        {
            if (decimal.TryParse(decimalAsString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result))
                return result;
            else
                throw new FormatException("The string cannot be parsed to decimal. " +
                    $"If there is a decimal point, it must be invariant ({CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator})");
        }

        public static string ToInvariantString(this decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
