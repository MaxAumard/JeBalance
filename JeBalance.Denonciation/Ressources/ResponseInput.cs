using System.Text.Json.Serialization;
using JeBalance.Domain.Models;

namespace JeBalance.Inspection.Ressources
{
    public class ResponseInput
    {
        [JsonPropertyName("retribution")]
        public float Retribution { get; set; }

        [JsonPropertyName("responseType")]
        public ResponseType ResponseType { get; set; }
    }
}
