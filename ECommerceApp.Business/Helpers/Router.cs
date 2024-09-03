namespace ECommerceApp.Business.Helpers
{
    public class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = $"{root}/{version}/";

        public static class AccountRouting
        {
            public const string Prefix = Rule + "Account/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

        public static class ProductRouting
        {
            public const string Prefix = Rule + "Products/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

        public static class OrderRouting
        {
            public const string Prefix = Rule + "Order/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }
        public static class BasketRouting
        {
            public const string Prefix = Rule + "Basket/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

        public static class UserRouting
        {
            public const string Prefix = Rule + "User/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string GetByUserName = Prefix + "{UserName}";
            public const string GetUserRoles = Prefix + "Id";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

    }
}
