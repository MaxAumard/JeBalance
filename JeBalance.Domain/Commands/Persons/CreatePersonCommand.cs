using JeBalance.Domain.Models;

namespace JeBalance.Domain.Commands.Persons
{
    public class CreatePersonCommand
    {
        public Person Person { get; set; }

        public CreatePersonCommand(Person person)
        {
            Person = person;
        }
    }
}
