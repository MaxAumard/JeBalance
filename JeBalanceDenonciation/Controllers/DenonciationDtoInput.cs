using System.Text.Json.Serialization;
using JeBalanceDenonciation.Models;

namespace JeBalanceDenonciation.Controllers
{
    public class DenonciationDtoInput
    {
        [JsonPropertyName("informateur")]
        public string Informateur { get; set; } = null!;

        [JsonPropertyName("suspect")]
        public string Suspect { get; set; } = null!;

        [JsonPropertyName("delit")]
        public Delit Delit { get; set; }

        [JsonPropertyName("pays")]
        public string Pays { get; set; } = null!;
    }
}
