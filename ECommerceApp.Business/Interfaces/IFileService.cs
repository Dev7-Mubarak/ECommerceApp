using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string FolderPath);
        Task<string> DeleteFileAsync(string URL, string FolderPath);
    }
}
