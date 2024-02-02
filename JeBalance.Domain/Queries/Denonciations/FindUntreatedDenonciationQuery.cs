using JeBalance.Domain.Models;
using MediatR;


namespace JeBalance.Domain.Queries.Denonciations
{
    public class FindUntreatedDenonciationQuery : IRequest<(IEnumerable<Denonciation> Results, int Total)>
    {
        public (int Limit, int Offset) Pagination { get; }
        public FindUntreatedDenonciationSpecification Specification { get; }

        public FindUntreatedDenonciationQuery(int limit, int offset)
        {
            Pagination = (limit, offset);
            Specification = new FindUntreatedDenonciationSpecification();
        }
    }
}