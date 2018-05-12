
namespace ModeloRelacionamentos.Domain.Dominio
{
    public class CursosPessoa
    {
        public int CodPessoa { get; set; }
        public int CodCursos { get; set; }
        public virtual Cursos Cursos { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
