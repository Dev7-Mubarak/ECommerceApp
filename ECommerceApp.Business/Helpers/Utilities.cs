using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Helpers
{
    public static class Utilities
    {
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;

        }
        public static async Task<string> SaveFileAsync(IFormFile sourseFile, string destination)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(sourseFile.FileName)}";

            var path = Path.Combine(destination, fileName);

            using var Stream = File.Create(path);

            await sourseFile.CopyToAsync(Stream);

            return fileName;
        }
        public static bool DeleteFile(string URL, string FolderPath)
        {
            try
            {
                var cover = Path.Combine(URL, FolderPath);
                File.Delete(cover);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
