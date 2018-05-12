
namespace ModeloRelacionamentos.Application.Service.Extensions
{
    public static class BooleanExtensions
    {
        public static string FormatarBooleano(this bool input)
        {
            return input ? "Sim" : "Não";
        }

        public static string FormatarBooleano(this bool? input)
        {
            return input.HasValue ? input.Value ? "Sim" : "Não" : string.Empty;
        }
    }
}
