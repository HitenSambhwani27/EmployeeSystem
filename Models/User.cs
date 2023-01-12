using System.ComponentModel.DataAnnotations;

namespace December_Project.Models
{
    public class User
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]

        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "password do not match to your confirm password")]

        public string ConfirmedPassword { get; set; }
    }
}
