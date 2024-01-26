using MediatR;
using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Commands.Persons;
using JeBalance.Domain.Queries.Persons;
using Microsoft.AspNetCore.Authorization;

namespace JeBalanceAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/v1/admin")]
    public class AdministrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdministrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("vip")]
        public async Task<IActionResult> GetVip() 
        {
            var query = new FindVIPPersonsQuery(0, 100 ,true);
            var vipPersons = await _mediator.Send(query);
            return Ok(vipPersons);
        }

        [HttpGet]
        [Route("non-vip")]
        public async Task<IActionResult> GetNonVip()
        {
            var query = new FindVIPPersonsQuery(0, 100,false);
            var nonVipPersons = await _mediator.Send(query);
            return Ok(nonVipPersons);
        }

        [HttpPost]
        [Route("vip/{id}")]
        public async Task<IActionResult> SetVip([FromRoute] string id, [FromQuery] bool isVIP) 
        {
            var command = new UpdatePersonIsVIPCommand(id, isVIP);
            var idPerson = await _mediator.Send(command);
            return Ok(idPerson);
        }
    }
}

