using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Interfaces;
using Ordering.Domain.AggregateModel.OrderAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Commads.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IMailSender _mailSender;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository,
            IMapper mapper,
            ILogger<CheckoutOrderCommandHandler> logger,
            IMailSender mailSender)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
        }
        public async Task<Unit> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Create(request.BuyerId, request.Username, request.TotalPrice, request.EmailAddress, request.Country, request.State, request.ZipCode);
            await _orderRepository.InsertAsync(order);
            _logger.LogInformation($"Order with order id - {order.Id} is successfully created");
             await _mailSender.SendMail(order);

            return Unit.Value;
        }
    }
}
