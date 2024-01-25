using System.Text.Json.Serialization;

namespace JeBalance.Inspection.Ressources
{
    public class PersonInput
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("address")]
        public AddressInput Address { get; set; }

        public PersonInput()
        {
        }
    }
}
