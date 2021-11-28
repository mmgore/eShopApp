using MediatR;
using System;

namespace Ordering.Application.Commads.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
