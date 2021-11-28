using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commads.CheckoutOrder;
using Ordering.Application.Commads.DeleteOrder;
using Ordering.Application.Commads.UpdateOrder;
using Ordering.Application.Queries.GetOrdersByUsername;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("api/v1/Orders/{username}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetOrdersByUsernameDto>> GetOrderByUsername(string username)
            => Ok(await _mediator.Send(new GetOrdersByUsernameQuery { Username = username }));

        [Route("api/v1/Orders")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckoutOrder([FromBody]CheckoutOrderCommand command)
            => Ok(await _mediator.Send(command));

        [Route("api/v1/Orders")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
            => Ok(await _mediator.Send(command));

        [Route("api/v1/Orders/{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
            => Ok(await _mediator.Send(new DeleteOrderCommand(id)));

    }
}
