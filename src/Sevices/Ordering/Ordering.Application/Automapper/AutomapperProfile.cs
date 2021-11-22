using AutoMapper;
using Ordering.Application.Queries.GetOrdersByUsername;
using Ordering.Domain.AggregateModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<GetOrdersByUsernameDto, Order>().ReverseMap();
        }
    }
}
