
using System.Collections.Generic;

namespace ModeloRelacionamentos.Domain.Dominio
{
    public class Cursos
    {
        public Cursos()
        {
            CursosPessoa = new List<CursosPessoa>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<CursosPessoa> CursosPessoa { get; set; }
    }
}
