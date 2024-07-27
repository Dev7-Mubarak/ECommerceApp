using ECommerceApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public T DeleteAsync(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
