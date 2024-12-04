using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(string id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var user = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var user = _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            var user = _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }
    }
}
