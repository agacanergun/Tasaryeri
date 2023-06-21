namespace Tasaryeri.WebUI.Models
{
    public class ShoppingCart
    {
        public int ProductId{ get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
