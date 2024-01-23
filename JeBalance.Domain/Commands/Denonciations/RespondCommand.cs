using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class RespondCommand : IRequest<string>
    {
        public string Id { get; }

        public Response Response { get; }

        public RespondCommand(string id, float retribution, ResponseType responseType)
        {
            Id = id;
            Response = new Response(DateTimeOffset.UtcNow, retribution, responseType);
        }
    }
}
