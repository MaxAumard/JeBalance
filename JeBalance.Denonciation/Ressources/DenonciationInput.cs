using System.Text.Json.Serialization;
using JeBalance.Domain.Models;

namespace JeBalance.Inspection.Ressources
{
    public class DenonciationInput
    {
        [JsonPropertyName("informant")]
        public string InformantId { get; set; } = null!;

        [JsonPropertyName("suspect")]
        public string SuspectId { get; set; } = null!;

        [JsonPropertyName("crime")]
        public Crime Crime { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;
    }
}
