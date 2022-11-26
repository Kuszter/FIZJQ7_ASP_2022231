using System.ComponentModel.DataAnnotations;

namespace FIZJQ7_ASP_2022231.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(2, ErrorMessage = "Minimum hossz 2")]
        [Display(Name = "Felhasználónév")]
        public string UserName { get; set; }

        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum hossz 4")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}