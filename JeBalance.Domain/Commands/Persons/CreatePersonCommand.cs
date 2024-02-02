using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Commands.Persons
{
    public class CreatePersonCommand : IRequest<string>
    {
        public Person Person { get; }

        public CreatePersonCommand(string firstName, string lastName, int number, string streetName, int postalCode,
            string city)
        {
            Person = new Person(Guid.NewGuid().ToString(), firstName, lastName,
                new Address(number, streetName, postalCode, city));
        }
    }
}