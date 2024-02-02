using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Queries.Persons
{
    public class FindVIPPersonsQuery : IRequest<(IEnumerable<Person> Results, int Total)>
    {
        public (int Limit, int Offset) Pagination { get; }
        public FindPersonsByVIPSpecification Specification { get; }

        public FindVIPPersonsQuery(int limit, int offset, bool isVIP)
        {
            Pagination = (limit, offset);

            Specification = new FindPersonsByVIPSpecification(isVIP);
        }
    }
}