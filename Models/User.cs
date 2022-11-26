using System.ComponentModel.DataAnnotations;

namespace FIZJQ7_ASP_2022231.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum hossz 2")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum hossz 4")]
        public string Password { get; set; }

        
    }
}
