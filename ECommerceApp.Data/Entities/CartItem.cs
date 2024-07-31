namespace ECommerceApp.Data.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProdutId { get; set; }

        public int Quantoty { get; set; }

        public int CartId { get; set; }

        public Product product { get; set; }

        public ShoppingCart cart { get; set; }
    }
}