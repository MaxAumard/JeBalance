using System.Text.Json.Serialization;

public class InspectionResponse
{
    [JsonPropertyName("retribution")] public float Retribution { get; set; }

    [JsonPropertyName("responseType")] public ResponseType ResponseType { get; set; }
}

public enum ResponseType
{
    None = 0,
    Confirmation = 1,
    Rejet = 2
}