using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Persons;

public class
    GetBannedPersonsQueryHandler : IRequestHandler<GetBannedPersonsQuery, (IEnumerable<Person> Results, int Total)>
{
    private readonly IPersonRepository _repository;

    public GetBannedPersonsQueryHandler(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<(IEnumerable<Person> Results, int Total)> Handle(GetBannedPersonsQuery query,
        CancellationToken cancellationToken)
    {
        return _repository.Find(
            query.Pagination.Limit,
            query.Pagination.Offset,
            query.Specification);
    }
}