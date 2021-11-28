using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Interfaces;
using Ordering.Domain.AggregateModel.BuyerAggregate;
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
        private readonly IBuyerRepository _buyerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IMailSender _mailSender;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository,
            IBuyerRepository buyerRepository,
            IUnitOfWork unitOfWork,
            ILogger<CheckoutOrderCommandHandler> logger,
            IMailSender mailSender)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
        }
        public async Task<Unit> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var buyer = Buyer.Create(request.FirstName, request.LastName, request.CardName, request.Expiration, request.CVV, request.PaymentMethod);
            var order = Order.Create(buyer.Id, request.Username, request.TotalPrice, request.EmailAddress, request.Country, request.State, request.ZipCode);
            
            await _orderRepository.InsertAsync(order);
            await _buyerRepository.InsertAsync(buyer);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation($"Order with order id - {order.Id} is successfully created");
             await _mailSender.SendMail(order);

            return Unit.Value;
        }
    }
}
