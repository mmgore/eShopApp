using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commads.CheckoutOrder;
using Ordering.Application.Exceptions;
using Ordering.Domain.AggregateModel.OrderAggregate;
using Ordering.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Commads.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository,
            IMapper mapper,
            ILogger<UpdateOrderCommandHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.Id);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation($"Order with order id - {order.Id} is successfully updated");

            return Unit.Value;
        }
    }
}
