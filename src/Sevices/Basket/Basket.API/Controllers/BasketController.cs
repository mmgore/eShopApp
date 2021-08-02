using Basket.API.Entities;
using Basket.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HttpGet]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CustomerBasket>> GetBasketAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest();
            }

            var basket = await _basketRepository.GetBasketAsync(username);
            return Ok(basket ?? new CustomerBasket(username));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateBasketAsync([FromBody] CustomerBasket basketItem)
        {
            return Ok(await _basketRepository.UpdateBasket(basketItem));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteBasketAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest();
            }

            await _basketRepository.DeleteBasketAsync(username);
            return Ok();
        }
    }
}
