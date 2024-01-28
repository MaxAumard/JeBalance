using JeBalance.Inspection.Ressources;
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Queries.Denonciations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Queries.Persons;
using JeBalance.Domain.Exceptions;

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
            try
            {
                var denonciation = await _mediator.Send(new GetDenonciationByIdQuery(id));
                var informant = await _mediator.Send(new GetPersonByIdQuery(denonciation.Informant));
                var suspect = await _mediator.Send(new GetPersonByIdQuery(denonciation.Suspect));
                return Ok(new DenonciationOutput(denonciation, informant, suspect));

            }
            catch (DenonciationNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (PersonNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost]
        [Route("denonciations")]
        public async Task<IActionResult> CreateDenonciation([FromBody] DenonciationInput input)
        {
            var command = new CreateDenonciationCommand(
                input.InformantDatas.FirstName,
                input.InformantDatas.LastName,
                input.InformantDatas.Address.ConvertToDomain(),
                input.SuspectDatas.FirstName,
                input.SuspectDatas.LastName,
                input.SuspectDatas.Address.ConvertToDomain(),
                input.Crime,
                input.Country);
            var id = await _mediator.Send(command);
            return Ok(id);
        }
            
    }
}
