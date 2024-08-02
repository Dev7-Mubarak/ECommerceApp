using ECommerceApp.Data.Entities;
using System.Linq.Expressions;

namespace ECommerceApp.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        T Update(T entity);
        Task<T> CreateAsync(T entity);
        void Delete(T entity);
      
    }
}


