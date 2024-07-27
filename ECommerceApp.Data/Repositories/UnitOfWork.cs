using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;

namespace ECommerceApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<Order> Orders { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new BaseRepository<Product>(_context);
            Orders = new BaseRepository<Order>(_context);
        }

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();
    }
}
