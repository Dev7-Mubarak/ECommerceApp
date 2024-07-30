using ECommerceApp.Data.Entities;

namespace ECommerceApp.Data.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
       
        IBaseRepository<Order> Orders { get; }
        Task<int> CompleteAsync();
    }
}
