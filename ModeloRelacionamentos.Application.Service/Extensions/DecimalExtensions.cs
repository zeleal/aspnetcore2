using System;

namespace ModeloRelacionamentos.Application.Service.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal input)
        {
            if (input == 0)
                return "0,00"; 

            return string.Format("{0:#.00}", input);
        }

        public static string ToRealBrasileiro(this decimal input)
        {
            if (input == 0)
                return "R$ 0,00";

            return "R$ " + string.Format("{0:#.00}", input);
        }
    }
}
