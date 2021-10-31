using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.Entities;
using WebApiUsuarios.Infrastructure.Data;
using WebApiUsuarios.Infrastructure.Repositories.IRepositories;

namespace WebApiUsuarios.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IBaseRepository<User> _usersRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IBaseRepository<User> UsersRepository => _usersRepository ?? new BaseRepository<User>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
