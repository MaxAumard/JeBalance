using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.SQLite.Model;

public static class Extensions
{
    public static Person ToDomain(this PersonneSQL person)
    {
        return new Person(
            person.Id,
            person.LastName,
            person.FirstName,
            Extensions.ToDomain(person.Address));
    }
    public static PersonneSQL ToSQL(this Person person)
    {
        return new PersonneSQL
        {
            Id = person.Id,
            LastName = person.FirstName.Value,
            FirstName = person.LastName.Value,
            Address = person.Address.ToSQL(),
        };
    }

    public static Address ToDomain(this String address)
    {
        string[] composantes = address.Split("/");
        
        return new Address(
            int.Parse(composantes[0]),
            new Name(composantes[1]),
            new PostalCode(int.Parse(composantes[2])),
            new Name(composantes[3]));
    }
    public static string ToSQL(this Address address)
    {
        return address.Number + ";" + address.StreetName + ";" + address.PostalCode + ";" + address.City;
    }

}
