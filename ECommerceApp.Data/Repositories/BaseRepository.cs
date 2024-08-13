using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceApp.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<T> CreateAsync(T entity) 
        {

            await _context.AddAsync(entity);
            return entity;
        }
        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Delete(T entity) => _context.Remove(entity);
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.ToListAsync();
        }
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
        public Product GetByName(string Name)
        {
            var product = _context.Products.Where(x => x.Name == "dd").FirstOrDefault();

            return product;
        }

    }
}







