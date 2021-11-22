using AutoMapper;
using MediatR;
using Ordering.Domain.AggregateModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Queries.GetOrdersByUsername
{
    public class GetOrdersByUsernameQueryHandler : IRequestHandler<GetOrdersByUsernameQuery, List<GetOrdersByUsernameDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersByUsernameQueryHandler(IOrderRepository orderRepository,
                                               IMapper mapper)
        {
            _orderRepository =  orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<GetOrdersByUsernameDto>> Handle(GetOrdersByUsernameQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserName(request.Username);
            return _mapper.Map<List<GetOrdersByUsernameDto>>(orders);
        }
    }
}
