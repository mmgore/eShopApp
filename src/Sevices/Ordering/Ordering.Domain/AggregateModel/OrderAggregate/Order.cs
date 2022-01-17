using Ordering.Domain.Exceptions;
using Ordering.Domain.SeedWork;
using System;

namespace Ordering.Domain.AggregateModel.OrderAggregate
{
    public class Order : Entity
    {
        public Guid BuyerId { get; private set; }
        public string Username { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string EmailAddress { get; private set; }
        public string AddressLine { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Order()
        {
        }

        public Order(Guid buyerId, string username, decimal totalPrice, string emailAddress, string country, string state, string zipCode)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            Username = !string.IsNullOrWhiteSpace(username) ? username
                                                            : throw new OrderingDomainException("Username cannot be null");
            TotalPrice = (totalPrice > 0) ? totalPrice
                                          : throw new OrderingDomainException("TotalPrice must be greater than 0");
            EmailAddress = !string.IsNullOrWhiteSpace(emailAddress) ? emailAddress
                                                            : throw new OrderingDomainException("EmailAddress cannot be null");
            Country = !string.IsNullOrWhiteSpace(country) ? country
                                                            : throw new OrderingDomainException("Country cannot be null"); 
            State = !string.IsNullOrWhiteSpace(state) ? state
                                                            : throw new OrderingDomainException("State cannot be null");
            ZipCode = !string.IsNullOrWhiteSpace(zipCode) ? zipCode
                                                            : throw new OrderingDomainException("ZipCode cannot be null");
        }

        public static Order Create(Guid buyerId, string username, decimal totalPrice, string emailAddress, string country, string state, string zipCode)
        {
            return new Order(buyerId, username, totalPrice, emailAddress, country, state, zipCode);
        }
    }
}
