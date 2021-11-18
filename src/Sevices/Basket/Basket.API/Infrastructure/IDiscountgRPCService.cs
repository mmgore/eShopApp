using Discount.gRPC.Protos;
using System.Threading.Tasks;

namespace Basket.API.Infrastructure
{
    public interface IDiscountgRPCService
    {
        Task<CouponModel> GetDiscount(string productName);
    }
}
