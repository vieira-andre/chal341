using System;

namespace chal341
{
    public static class Variables
    {
        public static string HomeCurrency => Environment.GetEnvironmentVariable("HomeCurrency") ?? ThrowExceptionForMissingVariable(nameof(HomeCurrency));

        public static string Locale => Environment.GetEnvironmentVariable("Locale") ?? ThrowExceptionForMissingVariable(nameof(Locale));

        private static string ThrowExceptionForMissingVariable(string variableName)
        {
            throw new ArgumentNullException($"Missing environment variable: ${variableName}");
        }
    }
}
