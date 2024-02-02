using System.ComponentModel.DataAnnotations;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Auth.Authentication;

public class RegisterModel
{
    [Required(ErrorMessage = "Firstame is required")]
    public string? Firstname { get; set; }

    [Required(ErrorMessage = "Lastname is required")]
    public string? Lastname { get; set; }

    [Required(ErrorMessage = "Number is required")]
    public int Number { get; set; }

    [Required(ErrorMessage = "StreetName is required")]
    public string? StreetName { get; set; }

    [Required(ErrorMessage = "PostalCode is required")]
    public int PostalCode { get; set; }

    [Required(ErrorMessage = "City is required")]
    public string? City { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}