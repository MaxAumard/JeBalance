﻿using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.SQLite.Model;

public static class Extensions
{
    //partie pour les personnes
    public static Person ToDomain(this PersonneSQL person)
    {
        return new Person(
            person.Id,
            person.LastName,
            person.FirstName,
            Extensions.ToDomain(person.Address),
            person.IsBanned,
            person.IsVIP)
            ;
    }
    public static PersonneSQL ToSQL(this Person person)
    {
        return new PersonneSQL
        {
            Id = person.Id,
            LastName = person.FirstName.Value,
            FirstName = person.LastName.Value,
            Address = person.Address.ToSQL(),
            IsBanned = person.IsBanned,
            IsVIP = person.IsVIP
        };
    }

    public static Address ToDomain(this String address)
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
        return address.Number + ";" + address.StreetName.Value + ";" + address.PostalCode.Value + ";" + address.City.Value;
    }

    //partie pour les denonciations
    public static Denonciation ToDomain(this DenonciationSQL denonciation)
    {
        return new Denonciation(
            denonciation.Id,
            denonciation.Informant,
            denonciation.Suspect,
            denonciation.Date,
            denonciation.Crime,
            denonciation.Pays,
            denonciation.Response);
    }

    public static DenonciationSQL ToSQL(this Denonciation denonciation)
    {
        return new DenonciationSQL
        {
            Id = denonciation.Id,
            Informant = denonciation.Informant,
            Suspect = denonciation.Suspect,
            Date = denonciation.Date,
            Crime = denonciation.Crime,
            Pays = denonciation.Pays.Value,
            //Response = denonciation.Response
        };
    }
}
