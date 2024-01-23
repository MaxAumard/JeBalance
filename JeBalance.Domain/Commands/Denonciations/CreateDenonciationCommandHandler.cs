using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, string>
    {
        private readonly IDenonciationRepository _repository;

        public CreateDenonciationCommandHandler(IDenonciationRepository repository) => _repository = repository;

        public Task<string> Handle(CreateDenonciationCommand command, CancellationToken cancellationToken)
        {
            return _repository.Create(command.Denonciation);
        }
    }
}
