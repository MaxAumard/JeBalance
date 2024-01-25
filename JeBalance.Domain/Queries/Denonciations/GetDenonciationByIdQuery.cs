using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class GetDenonciationByIdQuery : IRequest<Denonciation>
    {
        public string Id { get; }

        public GetDenonciationByIdQuery(string id)
        {
            Id = id;
        }
    }
}
