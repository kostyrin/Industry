using System.ComponentModel.DataAnnotations;
using Industry.Common.Enums;

namespace Industry.Front.API.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password should contain at least 6 characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirm password should match")]

        public string ConfirmPassword { get; set; }
       public LoginActions Action { get; set; }
    }
}