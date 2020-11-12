using System.ComponentModel.DataAnnotations;

namespace PublicData.WebClient.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
