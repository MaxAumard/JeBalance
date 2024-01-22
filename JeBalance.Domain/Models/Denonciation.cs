using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Models
{
    public class Denonciation : Entity
    {
        public string Informant { get; }
        public string Suspect { get; }
        public DateTimeOffset Date { get; }
        public Crime Crime { get; }
        public Name Country { get; }
        public Response? Response { get; }

        public Denonciation() : base(Guid.NewGuid().ToString())
        {
        }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, Name country, Response response) : base(id)
        {
            Informant = informant;
            Suspect = suspect;
            Date = date;
            Crime = crime;
            Country = country;
            Response = response;
        }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, string country, Response response) : this(
            id,
            informant,
            suspect,
            date,
            crime,
            new Name(country),
            response)
        { }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, Name country) : base(id)
        {
            Informant = informant;
            Suspect = suspect;
            Date = date;
            Crime = crime;
            Country = country;
            Response = null;
        }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, string country) : this(
            id,
            informant,
            suspect,
            date,
            crime,
            new Name(country))
        { }
    }
}
