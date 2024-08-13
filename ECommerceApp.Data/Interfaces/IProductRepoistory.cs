using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    internal interface IProductRepoistory<T> : IBaseRepository<T> where T : class
    {
        Task<T> GetByNameAsync(string Name);
    }
}
