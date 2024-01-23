
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Models;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Inspection.Ressources;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace JeBalance.Inspection.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class InspectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InspectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("open-denonciations")]
        public async Task<IActionResult> UntreatedDenonciations([FromQuery] FindUntreatedDenonciationDtoInput input)
        {
            var command = new FindUntreatedDenonciationQuery(input.Limit, input.Offset);
            var response = await _mediator.Send(command);
            var output = new PaginationOutput<DenonciationOutput>(response.Results.Select(place => new DenonciationOutput(place)), response.Total);
            return Ok(output);
        }

        [HttpPut("denonciations/{id}")]
        public async Task<IActionResult> UntreatedDenonciations([FromRoute] string id, [FromBody] ResponseInput input)
        {
            var command = new RespondCommand(id, input.Retribution, input.ResponseType);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
