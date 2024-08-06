using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Helpers
{
    public static class FileSetings
    {
        public const string ImagesPath = "/Assets/Product";
        public const string AllowedExtenstions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
