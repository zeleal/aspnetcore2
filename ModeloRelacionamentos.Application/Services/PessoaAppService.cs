using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModeloRelacionamentos.Domain.Dominio;
using ModeloRelacionamentos.Application.Interfaces;

namespace ModeloRelacionamentos.Application.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PessoaAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void ChangeDatabase(string database)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Pessoa FindById(int codigo)
        {
            return _unitOfWork.GetRepository<Pessoa>().GetAll().FirstOrDefault(ent => ent.Codigo == codigo);
        }

        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }
    }
}
