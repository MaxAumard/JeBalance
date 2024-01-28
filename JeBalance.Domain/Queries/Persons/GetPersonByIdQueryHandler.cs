using JeBalance.Domain.Exceptions;
using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Persons
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonRepository _repository;

        public GetPersonByIdQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetOne(query.Id) ?? throw new PersonNotFoundException(query.Id);
        }
    }
}
