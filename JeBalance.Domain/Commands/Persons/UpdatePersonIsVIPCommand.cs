using MediatR;

namespace JeBalance.Domain.Commands.Persons
{
    public class UpdatePersonIsVIPCommand : IRequest<string>
    {
        public string PersonId { get; }

        public bool IsVIP { get; }

        public UpdatePersonIsVIPCommand (string personId, bool isVIP)
        {
            PersonId = personId;
            IsVIP = isVIP;
        }
    }

}
