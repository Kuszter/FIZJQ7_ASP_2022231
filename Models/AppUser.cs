using Microsoft.AspNetCore.Identity;

namespace FIZJQ7_ASP_2022231.Models
{
    public class AppUser:IdentityUser
    {
        public string Role { get; set; }
    }
}
