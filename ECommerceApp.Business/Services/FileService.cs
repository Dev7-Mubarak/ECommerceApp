using AutoMapper;
using ECommerceApp.API.DTOs;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class FileService : IFileService 
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> DeleteFileAsync(string URL, string folderPath)
        {
            var fullPath = Path.Combine(_env.WebRootPath, folderPath, URL);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return "File deleted successfully.";
            }
            return "File not found.";
        }
    

    public async Task<string> SaveFileAsync(IFormFile file, string folderPath)
        {
            var uploadPath = Path.Combine(_env.WebRootPath, folderPath);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            //  return Path.Combine(folderPath, uniqueFileName);
            return uniqueFileName;
        }
    }
}
