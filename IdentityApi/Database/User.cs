using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Database;

public class User : IdentityUser
{
    public string? Initials { get; set; }
    
}