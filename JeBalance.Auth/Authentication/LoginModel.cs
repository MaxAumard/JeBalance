using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JeBalance.Administration.Authentication;

public class LoginModel
{
    [JsonPropertyName("username")] public string? Username { get; set; }

    [JsonPropertyName("password")] public string? Password { get; set; }
}