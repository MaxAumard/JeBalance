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

        public Task<Person> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken) => _repository.GetOne(query.Id);
    }
}
