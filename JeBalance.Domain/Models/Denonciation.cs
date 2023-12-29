using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Denonciation() : base(0)
        {
        }

        public Denonciation(string informant, string suspect, DateTimeOffset date, Crime crime, Name pays, Response response) : base(0)
        {
            Informant = informant;
            Suspect = suspect;
            Date = date;
            Crime = crime;
            Pays = pays;
            Response = response;
        }

        public Denonciation(string informant, string suspect, DateTimeOffset date, Crime crime, string pays, Response response) : this(
            informant,
            suspect,
            date,
            crime,
            new Name(pays),
            response)
        { }

        public Denonciation(string informant, string suspect, DateTimeOffset date, Crime crime, Name pays) : base(0)
        {
            Informant = informant;
            Suspect = suspect;
            Date = date;
            Crime = crime;
            Pays = pays;
            Response = null;
        }

        public Denonciation(string informant, string suspect, DateTimeOffset date, Crime crime, string pays) : this(
            informant,
            suspect,
            date,
            crime,
            new Name(pays))
        { }
    }
}
