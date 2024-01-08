namespace JeBalance.Domain.ValueObjects
{
    public class Address
    {
        public int  Number { get; }
        public Name StreetName { get; }
        public PostalCode PostalCode { get; }
        public Name City { get; }

        public Address()
        {
        }
        public Address(int number, Name streetName, PostalCode postalCode, Name city)
        {
            Number = number;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
        }

        public Address(int number, string streetName, int postalCode, string city) : this (
            number,
            new Name(streetName),
            new PostalCode(postalCode),
            new Name(city))
        { }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Address) return false;

            return obj is Address address &&
                   Number == address.Number &&
                   StreetName == address.StreetName &&
                   PostalCode == address.PostalCode &&
                   City == address.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, StreetName, PostalCode, City);
        }
    }
}
