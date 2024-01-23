using Microsoft.AspNetCore.Identity;

namespace JeBalance.Administration.Authentication;

public class ApplicationUser : IdentityUser
{
    public string AssociatedPersonId { get; set; }
}