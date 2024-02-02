using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.SQLite.Model;

public static class Extensions
{
    //partie pour les personnes
    public static Person ToDomain(this PersonSQL person)
    {
        return new Person(
                person.Id,
                person.FirstName,
                person.LastName,
                person.Address.ToDomainAddress(),
                person.IsBanned,
                person.IsVIP)
            ;
    }

    public static PersonSQL ToSQL(this Person person)
    {
        return new PersonSQL
        {
            Id = person.Id,
            LastName = person.LastName.Value,
            FirstName = person.FirstName.Value,
            Address = person.Address.ToSQL(),
            IsBanned = person.IsBanned,
            IsVIP = person.IsVIP
        };
    }

    public static Address ToDomainAddress(this String address)
    {
        string[] composantes = address.Split(";");

        return new Address(
            int.Parse(composantes[0]),
            new Name(composantes[1]),
            new PostalCode(int.Parse(composantes[2])),
            new Name(composantes[3]));
    }

    public static string ToSQL(this Address address)
    {
        return address.Number + ";" + address.StreetName.Value + ";" + address.PostalCode.Value + ";" +
               address.City.Value;
    }

    //partie pour les denonciations
    public static Denonciation ToDomain(this DenonciationSQL denonciation)
    {
        return new Denonciation(
            denonciation.Id,
            denonciation.InformantId,
            denonciation.SuspectId,
            denonciation.Date,
            denonciation.Crime,
            denonciation.Country,
            denonciation.Response?.ToDomainResponse()
        );
    }

    public static DenonciationSQL ToSQL(this Denonciation denonciation)
    {
        return new DenonciationSQL
        {
            Id = denonciation.Id,
            InformantId = denonciation.InformantId,
            SuspectId = denonciation.SuspectId,
            Date = denonciation.Date,
            Crime = denonciation.Crime,
            Country = denonciation.Country.Value,
            Response = denonciation?.Response?.ToSQL()
        };
    }

    public static string? ToSQL(this Response response)
    {
        if (response == null)
            return null;
        return response.Date + ";" + response.Retribution + ";" + response.ResponseType;
    }

    public static Response? ToDomainResponse(this String response)
    {
        if (response == null)
            return null;
        string[] composantes = response.Split(";");

        return new Response(
            DateTimeOffset.Parse(composantes[0]),
            int.Parse(composantes[1]),
            (ResponseType)Enum.Parse(typeof(ResponseType), composantes[2])
        );
    }
}