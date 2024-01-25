using JeBalance.Domain.Models;
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
            var informantId = await _personRepository.FindOrCreate(command.InformantFirstName, command.InformantLasttName, command.InformantAddress);
            var suspectId = await _personRepository.FindOrCreate(command.SuspectFirstName, command.SuspectLasttName, command.SuspectAddress);
            Denonciation denonciation = new Denonciation(command.Id, informantId, suspectId, command.Date, command.Crime, command.Country);
            return await _denonciationRepository.Create(denonciation);
        }
    }
}
