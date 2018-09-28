namespace ShoppingCart.Models
{
    public class Discount
    {
        public string Product { get; set; }
        public int Percentage { get; set; }
        public int Threshold { get; set; }
    }
}
