using System.Text.Json.Serialization;
using JeBalanceDenonciation.Models;

namespace JeBalanceDenonciation.Controllers
{
    public class ReponseDtoInput
    {
        [JsonPropertyName("retribution")]
        public float Retribution { get; set; }

        [JsonPropertyName("typeReponse")]
        public TypeReponse TypeReponse { get; set; }
    }
}
