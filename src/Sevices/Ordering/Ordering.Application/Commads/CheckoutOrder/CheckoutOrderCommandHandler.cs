using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Interfaces;
using Ordering.Domain.AggregateModel.OrderAggregate;
using Ordering.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Commads.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IMailSender _mailSender;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            ILogger<CheckoutOrderCommandHandler> logger,
            IMailSender mailSender)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
        }
        public async Task<Unit> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Create(request.BuyerId, request.Username, request.TotalPrice, request.EmailAddress, request.Country, request.State, request.ZipCode);
            await _orderRepository.InsertAsync(order);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation($"Order with order id - {order.Id} is successfully created");
             await _mailSender.SendMail(order);

            return Unit.Value;
        }
    }
}
