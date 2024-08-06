using ECommerceApp.Data.Entities;

namespace ECommerceApp.Data.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
       
        IBaseRepository<Basket> Baskets { get; }
        IBaseRepository<Product> Products { get; }
        IBaseRepository<Order> Orders { get; }
        Task<int> CompleteAsync();
    }
}
