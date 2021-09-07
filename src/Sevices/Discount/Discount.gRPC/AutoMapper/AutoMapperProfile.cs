using AutoMapper;
using Discount.gRPC.Entities;
using Discount.gRPC.Protos;

namespace Discount.gRPC.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
