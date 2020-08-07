using System.ComponentModel.DataAnnotations;

namespace PublicData.WebClient.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is in an invalid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
