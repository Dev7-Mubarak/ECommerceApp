namespace ECommerceApp.Data.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }

        public int ProdutId { get; set; }

        public int Quantity { get; set; }

        public int ShoppingCartId { get; set; }

        public decimal Price { get; set; }

        public Product product { get; set; }

        public Basket cart { get; set; }
    }
}