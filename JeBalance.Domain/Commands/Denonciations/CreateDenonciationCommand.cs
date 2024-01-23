using JeBalance.Domain.Models;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations
{
    public class CreateDenonciationCommand: IRequest<string>
    {
        public Denonciation Denonciation { get; }


        public CreateDenonciationCommand(string informantId, string suspectId, Crime crime, string country)
        {
            Denonciation = new Denonciation(Guid.NewGuid().ToString(), informantId, suspectId, DateTimeOffset.UtcNow, crime, country);
        }
    }
}
