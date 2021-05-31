using Basket.API.Entities;
using Basket.API.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.API.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task DeleteBasketAsync(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<CustomerBasket> GetBasketAsync(string username)
        {
            var basket = await _redisCache.GetStringAsync(username);

            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));
            return await GetBasketAsync(basket.Username);
        }
    }
}
