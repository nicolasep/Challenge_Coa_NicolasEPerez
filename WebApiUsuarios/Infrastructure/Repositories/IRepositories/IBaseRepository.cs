using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.Entities;
using WebApiUsuarios.Helper.Common;

namespace WebApiUsuarios.Infrastructure.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<Result> Update(T entity);
        Task<Result> Delete(int id);
    }
}
