using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace ECommerceApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Basket> Basksets { get; private set; }
        public IBaseRepository<Order> Orders { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }

      

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
           
            Orders = new BaseRepository<Order>(_context);
            Products = new BaseRepository<Product>(_context);
            Basksets = new BaseRepository<Basket>(_context);
          
        }

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();
    }
}
