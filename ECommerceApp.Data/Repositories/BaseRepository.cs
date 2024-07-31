using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceApp.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
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

        public void Delete(T entity) => _context.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return await query.ToListAsync();
            }

            return await _context.Set<T>().ToListAsync();

            //  return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, Expression<Func<T, object>>[] includes = null)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

       
    }
}







