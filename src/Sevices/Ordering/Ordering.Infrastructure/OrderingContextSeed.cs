using Microsoft.Extensions.Logging;
using Ordering.Domain.AggregateModel.BuyerAggregate;
using Ordering.Domain.AggregateModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class OrderingContextSeed
    {
        public static async Task SeedAsync(OrderingContext orderingContext, ILogger<OrderingContext> logger)
        {
            if (!orderingContext.Orders.Any())
            {
                var buyer = GetBuyer();
                orderingContext.Buyers.Add(buyer);
                orderingContext.Orders.AddRange(GetOrders(buyer.Id));
                await orderingContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetOrders(Guid buyerId)
        {
            return new List<Order>
            {
                
                Order.Create(buyerId, "test user", 20, "test@test.com","Galler", "Welsh", "2222")
            };
        }

        private static Buyer GetBuyer() => Buyer.Create("Test", "LastTest", "Visa", "14/11", "789", 3);
    }
}
