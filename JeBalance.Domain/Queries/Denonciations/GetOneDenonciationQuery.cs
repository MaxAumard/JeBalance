using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class GetOneDenonciationQuery : IRequest<Denonciation>
    {
        public string Id { get; }

        public GetOneDenonciationQuery(string id)
        {
            Id = id;
        }
    }
}
