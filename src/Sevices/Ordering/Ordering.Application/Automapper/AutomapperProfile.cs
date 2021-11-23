using AutoMapper;
using Ordering.Application.Commads.CheckoutOrder;
using Ordering.Application.Commads.UpdateOrder;
using Ordering.Application.Queries.GetOrdersByUsername;
using Ordering.Domain.AggregateModel.OrderAggregate;

namespace Ordering.Application.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<GetOrdersByUsernameDto, Order>().ReverseMap();
            CreateMap<CheckoutOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
        }
    }
}
