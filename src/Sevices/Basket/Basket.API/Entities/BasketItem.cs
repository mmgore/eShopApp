namespace Basket.API.Entities
{
    public class BasketItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
