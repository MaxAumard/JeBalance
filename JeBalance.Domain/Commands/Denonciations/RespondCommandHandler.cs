using System.Diagnostics.Metrics;
using JeBalance.Domain.Exceptions;
using JeBalance.Domain.Models;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class RespondCommandHandler : IRequestHandler<RespondCommand, string>
    {
        private readonly IDenonciationRepository _denonciationRepository;
        private readonly IPersonRepository _personRepository;

        public RespondCommandHandler(IDenonciationRepository denonciationRepository, IPersonRepository personRepository)
        {
            _denonciationRepository = denonciationRepository;
            _personRepository = personRepository;
        }

        public async Task<string> Handle(RespondCommand command, CancellationToken cancellationToken)
        {
            Denonciation denonciation = await _denonciationRepository.GetOne(command.Id);
            if (denonciation == null)
            {
                throw new DenonciationNotFoundException(command.Id);
            }
            else
            {
                if (denonciation.Response != null)
                {
                    throw new DenonciationAlreadyTreatedException(command.Id);
                }
                else
                {
                    var res = await _denonciationRepository.SetResponse(command.Id, command.Response);
                    if (command.Response.ResponseType.Equals(ResponseType.Rejet))
                    {
                        var nbOfDecline =
                            await _denonciationRepository.CountDeclinedDenonciations(denonciation.InformantId);
                        if (nbOfDecline >= 3)
                        {
                            await _personRepository.SetIsBanned(denonciation.InformantId, true);
                        }
                    }

                    return res;
                }
            }
        }
    }
}