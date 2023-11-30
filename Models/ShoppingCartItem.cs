namespace BasketSpa.API.Models
{
    public class ShoppingCartItem
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        //public int ProductDiscount { get; set; }
        public string? Decription { get; set; }

    }
}
