using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public DateTime DateOfBirth { get; set; }
}