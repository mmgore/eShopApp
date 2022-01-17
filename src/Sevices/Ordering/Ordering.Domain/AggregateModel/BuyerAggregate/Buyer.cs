using Ordering.Domain.Exceptions;
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
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CardName { get; private set; }
        public string Expiration { get; private set; }
        public string CVV { get; private set; }
        public int PaymentMethod { get; private set; }

        public Buyer()
        {
        }

        public Buyer(string firstName, string lastName, string cardName, string expiration, string cvv, int paymentMethod)
        {
            Id = Guid.NewGuid();
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName
                                                              : throw new BuyerDomainException("FirstName cannot be null");
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName
                                                              : throw new BuyerDomainException("LastName cannot be null");
            CardName = !string.IsNullOrWhiteSpace(cardName) ? cardName
                                                              : throw new BuyerDomainException("CardName cannot be null");
            Expiration = !string.IsNullOrWhiteSpace(expiration) ? expiration
                                                              : throw new BuyerDomainException("Expiration cannot be null");
            CVV = !string.IsNullOrWhiteSpace(cvv) ? cvv
                                                              : throw new BuyerDomainException("CVV cannot be null");
            PaymentMethod = paymentMethod;
        }

        public static Buyer Create(string firstName, string lastName, string cardName, string expiration, string cvv, int paymentMethod)
        {
            return new Buyer(firstName, lastName, cardName, expiration, cvv, paymentMethod);
        }
    }
}
