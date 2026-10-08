using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password dose not match")]
        public string ConfirmPassword { get; set; }
    }
}
