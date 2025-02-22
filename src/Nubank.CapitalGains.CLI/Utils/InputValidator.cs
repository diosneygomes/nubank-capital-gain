namespace Nubank.CapitalGains.CLI.Utils
{
    internal static class InputValidator
    {
        public static bool Validate(string input)
        {
            return !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);
        }
    }
}
