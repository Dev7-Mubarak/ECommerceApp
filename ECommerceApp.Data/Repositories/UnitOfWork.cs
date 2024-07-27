using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;

namespace ECommerceApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Product> Products { get; private set; }
      

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new BaseRepository<Product>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
