
namespace ModeloRelacionamentos.Domain.Dominio
{
    public class Endereco
    {
        public int Codigo { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public int CodigoPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
