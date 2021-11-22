using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Queries.GetOrdersByUsername
{
    public class GetOrdersByUsernameQuery : IRequest<List<GetOrdersByUsernameDto>>
    {
        public string Username { get; set; }
    }

    public class GetOrdersByUsernameDto
    {
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
