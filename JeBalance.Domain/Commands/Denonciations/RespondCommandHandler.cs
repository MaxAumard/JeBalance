using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class RespondCommandHandler : IRequestHandler<RespondCommand, string>
    {
        private readonly IDenonciationRepository _repository;
        public RespondCommandHandler(IDenonciationRepository repository) => _repository = repository;

        public Task<string> Handle(RespondCommand command, CancellationToken cancellationToken)
        {
            return _repository.SetResponse(command.Id, command.Response);
        }
    }
}
