using MediatR;
using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Commands.Persons;
using JeBalance.Domain.Queries.Persons;
using Microsoft.AspNetCore.Authorization;
using JeBalance.Administration.Ressources;

namespace JeBalanceAdmin.Controllers
{
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
        public async Task<IActionResult> GetVip([FromQuery] FindPersonsyVipStatusInput input) 
        {
            var query = new FindVIPPersonsQuery(input.Limit, input.Offset, true);
            var response = await _mediator.Send(query);
            var persons = response.Results
                .Select(persons => new PersonOutput(persons));
            return Ok(new PaginationOutput<PersonOutput>(persons, response.Total));
        }

        [HttpGet]
        [Route("non-vip")]
        public async Task<IActionResult> GetNonVip([FromQuery] FindPersonsyVipStatusInput input)
        {
            var query = new FindVIPPersonsQuery(input.Limit, input.Offset, false);
            var response = await _mediator.Send(query);
            var persons = response.Results
                .Select(persons => new PersonOutput(persons));
            return Ok(new PaginationOutput<PersonOutput>(persons, response.Total));
        }

        [HttpPut]
        [Route("vip/{id}")]
        public async Task<IActionResult> SetVip([FromRoute] string id, [FromQuery] bool isVIP) 
        {
            var command = new UpdatePersonIsVIPCommand(id, isVIP);
            var idPerson = await _mediator.Send(command);
            return Ok(idPerson);
        }
    }
}

