using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Persons
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public DeletePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(DeletePersonCommand command, CancellationToken cancellationToken)
        {
            return _repository.Delete(command.PersonId);
        }
    }
}