using Basket.API.Entities;
using Basket.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketRepository basketRepository
            , ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ActionResult<CustomerBasket>> GetBasket(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest();
            }
            var basket = await _basketRepository.GetBasketAsync(username);
            if (basket == null)
            {
                _logger.LogError($"Basket with username: {username} - not found");
                return NotFound();
            }
            return Ok(basket);
        }
    }
}
