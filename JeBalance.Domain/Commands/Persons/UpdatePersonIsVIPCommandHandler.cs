using JeBalance.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.Persons
{

    public class UpdatePersonIsVIPCommandHandler : IRequestHandler<UpdatePersonIsVIPCommand, string>
    {
        private readonly IPersonRepository _repository;

        public UpdatePersonIsVIPCommandHandler(IPersonRepository repository) => _repository = repository;

        public Task<string> Handle(UpdatePersonIsVIPCommand command, CancellationToken cancellationToken)
        {
            return _repository.SetIsVIP(command.PersonId, command.IsVIP);
        }

    }
}
