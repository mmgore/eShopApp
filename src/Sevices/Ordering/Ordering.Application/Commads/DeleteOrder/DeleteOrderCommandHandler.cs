using MediatR;
using Ordering.Application.Exceptions;
using Ordering.Domain.AggregateModel.OrderAggregate;
using Ordering.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Commads.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.Id);

            if(order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            await _orderRepository.DeleteAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
