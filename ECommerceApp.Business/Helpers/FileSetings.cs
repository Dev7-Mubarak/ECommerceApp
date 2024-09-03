namespace ECommerceApp.Business.Helpers
{
    public static class FileSetings
    {
        public const string ProductsImagesPath = "/Assets/Product";
        public const string UsersImagesPath = "/Assets/Users";
        public const string AllowedExtenstions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
