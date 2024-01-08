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
        public Name Pays { get; }
        public Response? Response { get; }

        public Denonciation() : base(Guid.NewGuid().ToString())
        {
        }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, Name pays, Response response) : base(id)
        {
            Informant = informant;
            Suspect = suspect;
            Date = date;
            Crime = crime;
            Pays = pays;
            Response = response;
        }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, string pays, Response response) : this(
            id,
            informant,
            suspect,
            date,
            crime,
            new Name(pays),
            response)
        { }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, Name pays) : base(id)
        {
            Informant = informant;
            Suspect = suspect;
            Date = date;
            Crime = crime;
            Pays = pays;
            Response = null;
        }

        public Denonciation(string id, string informant, string suspect, DateTimeOffset date, Crime crime, string pays) : this(
            id,
            informant,
            suspect,
            date,
            crime,
            new Name(pays))
        { }
    }
}
