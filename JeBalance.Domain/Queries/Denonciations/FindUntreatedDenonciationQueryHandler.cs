﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class FindUntreatedDenonciationQueryHandler : IRequestHandler<FindUntreatedDenonciationQuery, (IEnumerable<Denonciation> Results, int Total)>
    {
        private readonly IDenonciationRepository _repository;

        public FindUntreatedDenonciationQueryHandler(IDenonciationRepository repository) => _repository = repository;


        public Task<(IEnumerable<Denonciation> Results, int Total)> Handle(FindUntreatedDenonciationQuery query, CancellationToken cancellationToken)
        {
            return _repository.Find(
                query.Pagination.Limit,
                query.Pagination.Offset,
                query.Specification);
        }
    }
}