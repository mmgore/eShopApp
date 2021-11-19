using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.AggregateModel.BuyerAggregate
{
    public class Buyer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardName { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
    }
}
