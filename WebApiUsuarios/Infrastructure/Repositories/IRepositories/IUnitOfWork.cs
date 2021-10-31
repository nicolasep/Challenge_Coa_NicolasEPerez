using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.Entities;

namespace WebApiUsuarios.Infrastructure.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IBaseRepository<User> UsersRepository { get; }
        void Dispose();
        Task SaveChangesAsync();
    }
}
