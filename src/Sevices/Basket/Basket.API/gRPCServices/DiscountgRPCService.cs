using Basket.API.Infrastructure;
using Discount.gRPC.Protos;
using System;
using System.Threading.Tasks;

namespace Basket.API.gRPCServices
{
    public class DiscountgRPCService : IDiscountgRPCService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public DiscountgRPCService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };

            return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
        }
    }
}
