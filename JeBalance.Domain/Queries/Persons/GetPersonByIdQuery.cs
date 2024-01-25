using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Queries.Persons
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public string Id { get; }

        public GetPersonByIdQuery(string id)
        {
            Id = id;
        }
    }
}
