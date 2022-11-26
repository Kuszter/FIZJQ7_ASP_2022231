using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIZJQ7_ASP_2022231.Models
{
    public class AppUser:IdentityUser
    {
        [NotMapped]
        public string Occupation { get; set; }
    }
}
