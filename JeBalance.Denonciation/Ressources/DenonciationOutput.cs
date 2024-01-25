using System.Text.Json.Serialization;
using JeBalance.Domain.Models;

namespace JeBalance.Inspection.Ressources
{
    public class DenonciationOutput
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("informant")]
        public PersonOutput Informant { get; set; } 

        [JsonPropertyName("suspect")]
        public PersonOutput Suspect { get; set; } 

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("crime")]
        public Crime Crime { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("response")]
        public Response? Response { get; set; }

        public DenonciationOutput()
        {
        }

        public DenonciationOutput(Denonciation source, Person informant, Person suspect)
        {
            Id = source.Id;
            Informant = new PersonOutput(informant);
            Suspect = new PersonOutput(suspect);
            Date = source.Date;
            Crime = source.Crime;
            Country = source.Country;
            Response = source.Response;
        }
    }
}
