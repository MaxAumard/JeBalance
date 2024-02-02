using JeBalance.Domain.Exceptions;
using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class GetDenonciationByIdQueryHandler : IRequestHandler<GetDenonciationByIdQuery, Denonciation>
    {
        private readonly IDenonciationRepository _repository;

        public GetDenonciationByIdQueryHandler(IDenonciationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Denonciation> Handle(GetDenonciationByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetOne(query.Id) ?? throw new DenonciationNotFoundException(query.Id);
        }
    }
}