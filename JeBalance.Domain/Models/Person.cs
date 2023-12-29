using System.Runtime.CompilerServices;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Models
{
    public class Person : Entity
    {
        public Name FirstName { get; }
        public Name LastName { get; }
        public Address Address { get; }
        public bool IsBanned { get; }

        public Person() : base(0)
        {
        }

        public Person(int id, Name firstName, Name lastName, Address address, bool isBanned) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsBanned = isBanned;
        }

        public Person(int id, string firstName, string lastName, Address address, bool isBanned) : this(
            id,
            new Name(firstName),
            new Name(lastName),
            address,
            isBanned
            ) 
        { }

        public Person(int id, string firstName, string lastName, Address address) : this(
            id,
            new Name(firstName),
            new Name(lastName),
            address,
            false
            )
        { }

    }
}
