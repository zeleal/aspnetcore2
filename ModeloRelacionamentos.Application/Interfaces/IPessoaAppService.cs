using Microsoft.EntityFrameworkCore;
using ModeloRelacionamentos.Domain.Dominio;

namespace ModeloRelacionamentos.Application.Interfaces
{
    public interface IPessoaAppService : IUnitOfWork
    {
        Pessoa FindById(int codigo);
    }
}
