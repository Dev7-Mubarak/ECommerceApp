namespace ECommerceApp.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        T Update(T entity);
        Task<T> AddAsync(T entity);
        T Delete(int id);
    }
}