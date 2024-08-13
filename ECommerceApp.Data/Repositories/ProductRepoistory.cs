using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    internal class ProductRepoistory<T> : BaseRepository<T> where T : Product
    {
        public ProductRepoistory(ApplicationDbContext context) : base(context)
        {
        }





    }
}
