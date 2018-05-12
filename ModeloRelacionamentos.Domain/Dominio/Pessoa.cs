using System;
using System.Collections.Generic;

namespace ModeloRelacionamentos.Domain.Dominio
{
    public class Pessoa
    {
        public Pessoa()
        {
            Filhos = new List<Filhos>();
            CursosPessoa = new List<CursosPessoa>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Filhos> Filhos { get; set; }
        public virtual ICollection<CursosPessoa> CursosPessoa { get; set; }
    }
}
