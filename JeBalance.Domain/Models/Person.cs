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

        public bool IsVIP { get; }
        public Person() : base(Guid.NewGuid().ToString())
        {
        }

        public Person(string id, Name firstName, Name lastName, Address address, bool isBanned, bool isVIP) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsBanned = isBanned;
            IsVIP = isVIP;
        }

        public Person(string id, string firstName, string lastName, Address address, bool isBanned, bool isVIP) : this(
            id,
            new Name(firstName),
            new Name(lastName),
            address,
            isBanned,
            isVIP
            ) 
        { }

        public Person(string id, string firstName, string lastName, Address address) : this(
            id,
            new Name(firstName),
            new Name(lastName),
            address,
            false,
            false
            )
        { }

    }
}
