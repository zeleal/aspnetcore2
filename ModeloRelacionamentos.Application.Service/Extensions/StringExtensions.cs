using System;
using System.Text.RegularExpressions;

namespace ModeloRelacionamentos.Application.Service.Extensions
{
    public static class StringExtesions
    {
        public static string ToCPF(this string input)
        {
            if (input.Length.Equals(11))
                input = Regex.Replace(input, "^(\\d{3})(\\d{3})(\\d{3})(\\d{2})$", "$1.$2.$3-$4");

            return input;
        }

        public static string ToCNPJ(this string input)
        {
            if (input.Length.Equals(14))
            {
                input = Regex.Replace(input, "^(\\d{2})(\\d{3})(\\d{3})(\\d{4})(\\d{2})$", "$1.$2.$3/$4-$5");
            }

            return input;
        }

        public static string ToCEP(this string input)
        {
            if (input.Length.Equals(8))
                input = Regex.Replace(input, "^(\\d{5})(\\d{3})$", "$1-$2");

            return input;
        }

        public static string ToPhone(this string input)
        {
            string extraDigit = "^(\\d{2})(\\d{5})(\\d{4})$";
            string defaultPattern = "^(\\d{2})(\\d{4})(\\d{4})$";

            input = Regex.Replace(input, (input.Length.Equals(10) ? defaultPattern : extraDigit), "($1) $2-$3");

            return input;
        }

        public static string ToNumbers(this string input)
        {
            if (input != null && input != String.Empty)
            {
                return Regex.Replace(input, @"[^\d]", "");
            }

            return String.Empty;
        }

        public static string Truncate(this string input, int length)
        {
            if (input.Length < length)
                return input;

            return string.Format("{0}...", input.Substring(0, length - 1));
        }
    }
}
