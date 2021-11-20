using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregateModel.BuyerAggregate;
using Ordering.Domain.AggregateModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class OrderingContext : DbContext
    {
        public OrderingContext(DbContextOptions<OrderingContext> options): base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
    }
}
