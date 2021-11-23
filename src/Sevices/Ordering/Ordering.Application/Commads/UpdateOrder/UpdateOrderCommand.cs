using MediatR;
using System;

namespace Ordering.Application.Commads.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; private set; }
        public string Username { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string EmailAddress { get; private set; }
        public string AddressLine { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
    }
}
