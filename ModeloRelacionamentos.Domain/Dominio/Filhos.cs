
namespace ModeloRelacionamentos.Domain.Dominio
{
    public class Filhos
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int? CodigoPai { get; set; }
        public virtual Pessoa Pai { get; set; }
    }
}
