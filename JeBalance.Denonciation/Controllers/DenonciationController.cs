using JeBalance.Inspection.Ressources;
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Queries.Denonciations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.Inspection.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class DenonciationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DenonciationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("denonciations/{id}")]
        public async Task<IActionResult> GetDenonciation([FromRoute] string id)
        {
            var query = new GetOneDenonciationQuery(id);
            var denonciation = await _mediator.Send(query);
            return Ok(new DenonciationOutput(denonciation));
        }

        [HttpPost]
        [Route("denonciations")]
        public async Task<IActionResult> CreateDenonciation([FromBody] DenonciationInput input)
        {
            var command = new CreateDenonciationCommand(input.InformantId, input.SuspectId, input.Crime, input.Country);
            var id = await _mediator.Send(command);
            return Ok(id);
        }

    }
}
