using System.Text.Json.Serialization;
using JeBalance.Domain.Models;

namespace JeBalance.Inspection.Ressources
{
    public class DenonciationOutput
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("informant")]
        public string Informant { get; set; } = null!;

        [JsonPropertyName("suspect")]
        public string Suspect { get; set; } = null!;

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("crime")]
        public Crime Crime { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("response")]
        public Response? Response { get; set; } = null!;

        public DenonciationOutput()
        {
        }

        public DenonciationOutput(Denonciation source)
        {
            Id = source.Id;
            Informant = source.Informant;
            Suspect = source.Suspect;
            Date = source.Date;
            Crime = source.Crime;
            Country = source.Country;
            Response = source.Response;
        }
    }
}
