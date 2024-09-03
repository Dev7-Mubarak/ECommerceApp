using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Business.Helpers
{
    public static class Utilities
    {
        public static void CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }

        }
        private static string ReplaceFileNameWithGUID(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            return Guid.NewGuid() + extension;
        }
        // return Tuple
        public static async Task<(bool Succeeded, string FileName)> SaveFileAsync(IFormFile file, string destination)
        {

            CreateFolderIfDoesNotExist(destination);

            try
            {
                var newFileName = ReplaceFileNameWithGUID(file);

                var newFilPath = Path.Combine(destination, newFileName);

                using (var Stream = new FileStream(newFilPath, FileMode.Create))
                {
                    await file.CopyToAsync(Stream);
                }

                return (true, newFileName);
            }
            catch (Exception ex)
            {
                return (false, string.Empty);
            }
        }
        public static bool DeleteFile(string file, string destination)
        {
            try
            {
                var FilePath = Path.Combine(destination, file);

                File.Delete(FilePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
