
using JeBalance.Domain.Queries.Denonciations;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace JeBalance.Inspection.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class InspectionControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public InspectionControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*
        [HttpGet("open-denonciations")]
        public async Task<IActionResult> UntreatedDenonciations()
        {
            var command = new FindUntreatedDenonciations();
            var denonciations = await _mediator.Send(command);
            return Ok(denonciations);
        }
        */
    }
}
