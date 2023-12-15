using System.Text.Json.Serialization;
using JeBalanceDenonciation.Models;

namespace JeBalanceDenonciation.Controllers
{
    public class DenonciationDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("informateur")]
        public string Informateur { get; set; } = null!;

        [JsonPropertyName("suspect")]
        public string Suspect { get; set; } = null!;

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("delit")]
        public Delit Delit { get; set; }

        [JsonPropertyName("pays")]
        public string Pays { get; set; } = null!;

        public Reponse Reponse { get; set; } = null!;
    }
}
