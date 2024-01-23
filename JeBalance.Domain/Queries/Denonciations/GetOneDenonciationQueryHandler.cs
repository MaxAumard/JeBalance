using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class GetOneDenonciationQueryHandler: IRequestHandler<GetOneDenonciationQuery, Denonciation>
    {
        private readonly IDenonciationRepository _repository;

        public GetOneDenonciationQueryHandler(IDenonciationRepository repository)
        {
            _repository = repository;
        }

        public Task<Denonciation> Handle(GetOneDenonciationQuery query, CancellationToken cancellationToken) => _repository.GetOne(query.Id);
    }
}
