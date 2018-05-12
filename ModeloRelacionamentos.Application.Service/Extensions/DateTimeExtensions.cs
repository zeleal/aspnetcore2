using System;

namespace ModeloRelacionamentos.Application.Service.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FormatarData(this DateTime input)
        {
            return input.ToString("dd/MM/yyyy HH:mm");
        }

        public static string FormatarData(this DateTime? input)
        {
            return input.HasValue ? input.Value.ToString("dd/MM/yyyy HH:mm") : "-";
        }

        public static string FormatarData(this DateTime? input, string format)
        {
            return input.HasValue ? input.Value.ToString(format) : "-";
        }

        public static string FormatarData(this DateTime input, string format)
        {
            return String.IsNullOrEmpty(format) ? input.ToString("dd/MM/yyyy HH:mm") : input.ToString(format);
        }

        public static bool IsBetween(this DateTime dt, DateTime start, DateTime end)
        {
            return dt >= start && dt <= end;
        }
    }
}
