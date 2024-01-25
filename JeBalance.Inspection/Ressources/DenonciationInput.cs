using System.Text.Json.Serialization;
using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Inspection.Ressources
{
    public class DenonciationInput
    {
        [JsonPropertyName("informantDatas")]
        public PersonInput InformantDatas { get; set; }

        [JsonPropertyName("suspectDatas")]
        public PersonInput SuspectDatas { get; set; }

        [JsonPropertyName("crime")]
        public Crime Crime { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public static class Extension {

        public static Address ConvertToDomain(this AddressInput address)
        {
            return new Address(
                address.Number,
                address.StreetName,
                address.PostalCode,
                address.City
            );
        }
    }
}
