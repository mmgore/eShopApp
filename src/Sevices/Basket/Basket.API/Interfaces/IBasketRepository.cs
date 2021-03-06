using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string username);
        Task<CustomerBasket> UpdateBasket(CustomerBasket basket);
        Task DeleteBasketAsync(string userName);
    }
}
