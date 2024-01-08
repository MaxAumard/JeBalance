using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Persons;

public class GetVIPPersonsQueryHandler : IRequestHandler<GetVIPPersonsQuery, (IEnumerable<Person> Results, int Total)>
{
    private readonly IPersonRepository _repository;

    public GetVIPPersonsQueryHandler(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<(IEnumerable<Person> Results, int Total)> Handle(GetVIPPersonsQuery query, CancellationToken cancellationToken)
    {
        return _repository.Find(
            query.Pagination.Limit,
            query.Pagination.Offset,
            query.Specification);
    }
}
