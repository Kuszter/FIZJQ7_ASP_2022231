namespace FIZJQ7_ASP_2022231.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> cartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
