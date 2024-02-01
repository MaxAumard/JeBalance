using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Exceptions;
using JeBalance.Domain.Models;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.Queries.Persons;
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

        
        [HttpGet("denonciations")]
        public async Task<IActionResult> UntreatedDenonciations([FromQuery] FindUntreatedDenonciationDtoInput input)
        {
            var command = new FindUntreatedDenonciationQuery(input.Limit, input.Offset);
            var response = await _mediator.Send(command);
            var denonciations = response.Results.
                Select(denonciation => GetDenonciationOutput(denonciation).Result);
            var output = new PaginationOutput<DenonciationOutput>(denonciations, response.Total);
            return Ok(output);
        }

        private async Task<DenonciationOutput> GetDenonciationOutput(Denonciation denonciation)
        {
            try
            {
                var informant = await _mediator.Send(new GetPersonByIdQuery(denonciation.InformantId));
                var suspect = await _mediator.Send(new GetPersonByIdQuery(denonciation.SuspectId));
                return new DenonciationOutput(denonciation, informant, suspect);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("denonciations/{id}")]
        public async Task<IActionResult> RespondDeconciation([FromRoute] string id, [FromBody] ResponseInput input)
        {
            try
            {
                var command = new RespondCommand(id, input.Retribution, input.ResponseType);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (DenonciationNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DenonciationAlreadyTreatedException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
