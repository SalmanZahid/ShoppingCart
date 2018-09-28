namespace ShoppingCart.Models
{
    public class Item
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } = 1;
        public int TotalPrice { get; set; }
    }
}
