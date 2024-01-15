using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.Persons
{
    public class UpdatePersonIsVIPCommand : IRequest<string>
    {
        public string PersonId { get; }

        public bool IsVIP { get; }

        public UpdatePersonIsVIPCommand (string personId, bool isVIP)
        {
            PersonId = personId;
            IsVIP = isVIP;
        }
    }

}
