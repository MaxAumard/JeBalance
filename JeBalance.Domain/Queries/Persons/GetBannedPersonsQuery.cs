using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Queries.Persons
{
    public class GetBannedPersonsQuery : IRequest<(IEnumerable<Person> Results, int Total)>
    {
        public (int Limit, int Offset) Pagination { get; }
        public Specification<Person> Specification { get; }

        public GetBannedPersonsQuery(int limit, int offset, bool isBanned)
        {
            Pagination = (limit, offset);

            Specification = new FindPersonsByBannedSpecification(isBanned);
        }
    }
}
