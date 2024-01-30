using JeBalance.Domain.Exceptions;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class RespondCommandHandler : IRequestHandler<RespondCommand, string>
    {
        private readonly IDenonciationRepository _repository;
        public RespondCommandHandler(IDenonciationRepository repository) => _repository = repository;

        public async Task<string> Handle(RespondCommand command, CancellationToken cancellationToken)
        {
             return await _repository.SetResponse(command.Id, command.Response) ?? throw new DenonciationNotFoundException(command.Id);
        }
    }
}
