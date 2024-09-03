using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IEmailServices 
    {
        Task<string> SendEmailAsync(string email, string subject, string body, IList<IFormFile> formFiles = null);

    }
}
