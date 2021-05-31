using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class CustomerBasket
    {
        public string Username { get; set; }
        public List<BasketItem> Items { get; set; }
        public CustomerBasket(string username)
        {
            Username = username;
            Items = new List<BasketItem>();
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                Items.ForEach(item =>
                {
                    totalPrice += item.Price * item.Quantity;
                });
                return totalPrice;
            }
        }
    }
}
