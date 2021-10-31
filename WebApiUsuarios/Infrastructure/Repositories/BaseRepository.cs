using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiUsuarios.Entities;
using WebApiUsuarios.Infrastructure.Data;
using WebApiUsuarios.Infrastructure.Repositories.IRepositories;
using WebApiUsuarios.Helper.Common;

namespace WebApiUsuarios.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entity;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var response = await _entity.ToListAsync();
            return response;
        }
        public async Task<T> GetById(int id)
        {
            var response = await _entity.FindAsync(id);
            return response;
        }
        public async Task<T> Insert(T entity)
        {
            var response = await _entity.AddAsync(entity);
            return response.Entity;
        }
        public Task<Result> Update(T entity)
        {
            if (entity == null) return Task.FromResult(new Result().Fail("El id no existe"));
            
            _context.Set<T>().Update(entity);
            return Task.FromResult(new Result().Success($"Se ha actualizado correctamente"));
        }
        public async Task<Result> Delete(int id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity == null) return new Result().Fail("El id no existe");
            
            _entity.Remove(entity);
            return new Result().Success($"Se ha borrado correctamente");
        }
    }
}
