using System;
using ModeloRelacionamentos.Domain.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ModeloRelacionamentos.Infra
{
    public interface ApplicationUoW : IDisposable, IUnitOfWork
    {
        
        IRepository<Pessoa> Pessoa { get; set; }
        IRepository<Endereco> Endereco { get; set; }
        IRepository<Filhos> Filhos { get; set; }
    }
}
