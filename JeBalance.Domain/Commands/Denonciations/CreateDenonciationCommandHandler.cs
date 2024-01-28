using JeBalance.Domain.Models;
using JeBalance.Domain.Queries.Persons;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, string>
    {
        private readonly IDenonciationRepository _denonciationRepository;
        private readonly IPersonRepository _personRepository;

        public CreateDenonciationCommandHandler(IDenonciationRepository denonciationRepository, IPersonRepository personRepository) {
            _denonciationRepository = denonciationRepository;
            _personRepository = personRepository;
        }

        public async Task<string> Handle(CreateDenonciationCommand command, CancellationToken cancellationToken)
        {
            var informantId = await _personRepository.GetPerson(new FindPersonByPersonalDataSpecification(command.InformantFirstName, command.InformantLastName, command.InformantAddress));
            if (string.IsNullOrEmpty(informantId))
            {
                informantId = await _personRepository.Create(new Person(
                    Guid.NewGuid().ToString(),
                    command.InformantFirstName,
                    command.InformantLastName,
                    command.InformantAddress
                    ));
            }
            var suspectId = await _personRepository.GetPerson(new FindPersonByPersonalDataSpecification(command.SuspectFirstName, command.SuspectLastName, command.SuspectAddress));
            if (string.IsNullOrEmpty(suspectId))
            {
                suspectId = await _personRepository.Create(new Person(
                    Guid.NewGuid().ToString(),
                    command.SuspectFirstName,
                    command.SuspectLastName,
                    command.SuspectAddress
                    ));

            }
            Denonciation denonciation = new Denonciation(command.Id, informantId, suspectId, command.Date, command.Crime, command.Country);
            return await _denonciationRepository.Create(denonciation);
        }
    }
}
