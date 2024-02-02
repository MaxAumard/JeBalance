using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Persons;

public class FindVIPPersonsQueryHandler : IRequestHandler<FindVIPPersonsQuery, (IEnumerable<Person> Results, int Total)>
{
    private readonly IPersonRepository _repository;

    public FindVIPPersonsQueryHandler(IPersonRepository personRepository)
    {
        _repository = personRepository;
    }


    public Task<(IEnumerable<Person> Results, int Total)> Handle(FindVIPPersonsQuery query,
        CancellationToken cancellationToken)
    {
        return _repository.Find(
            query.Pagination.Limit,
            query.Pagination.Offset,
            query.Specification);
    }
}