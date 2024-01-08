using JeBalance.Domain.Models;
using JeBalance.Domain.Queries.Denonciations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JeBalanceAdmin.Controllers
{

    [ApiController]
    [Route("api")]
    public class InspectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InspectController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("open-denonciations")]
        public async Task<IActionResult> untreatedDenonciations() 
        {
            var command = new FindUntreatedDenonciations();
            var denonciations = await _mediator.Send(command);
            return Ok(denonciations);
        }
}
}

