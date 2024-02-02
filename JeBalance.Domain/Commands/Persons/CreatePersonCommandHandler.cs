using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.Persons;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, string>
{
    private readonly IPersonRepository _personRepository;


    public CreatePersonCommandHandler(
        IPersonRepository personRepository
    )
    {
        _personRepository = personRepository;
    }

    public async Task<string> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        return await _personRepository.Create(command.Person);
    }
}