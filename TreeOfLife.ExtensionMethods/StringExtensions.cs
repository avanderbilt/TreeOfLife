using System.Linq;

namespace TreeOfLife.ExtensionMethods
{
    public static class StringExtensions
    {
        private const string ParameterDelimiter = "--";

        public static string Repeat(this string value, int numberOfTimes)
        {
            return string.Concat(Enumerable.Repeat(value, numberOfTimes));
        }

        public static string Pluralize(this string value, int count)
        {
            return count == 1 ? value : $"{value}s";
        }

        public static bool ArgumentIsOption(this string value)
        {
            if (value.StartsWith(ParameterDelimiter))
                return true;

            return false;
        }

        public static string OptionWithoutDelimiter(this string value)
        {
            if (value.StartsWith(ParameterDelimiter))
                return value.Substring(ParameterDelimiter.Length);

            return value;
        }
    }
}