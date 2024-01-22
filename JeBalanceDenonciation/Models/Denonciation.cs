using System.Globalization;

namespace JeBalanceDenonciation.Models
{
    public class Denonciation
    {
        public string Id { get; set; }

        public string Informateur { get; }

        public string Suspect { get; }

        public DateTimeOffset Date { get ;}

        public Delit Delit { get; }

        public string Pays { get; }

        public Reponse? Reponse { get; set; }

        public Denonciation(string id, string informateur, string suspect, DateTimeOffset date, Delit delit, string pays, Reponse? reponse)
        {
            Id = id;
            Informateur = informateur;
            Suspect = suspect;
            Date = date;
            Delit = delit;
            Pays = pays;
            Reponse = reponse;
        }

        public Denonciation(string informateur, string suspect, Delit delit, string pays)
        {
            Id = Guid.NewGuid().ToString();
            Informateur = informateur;
            Date = DateTimeOffset.UtcNow;
            Suspect = suspect;
            Delit = delit;
            Pays = pays;
        }
    }
}
