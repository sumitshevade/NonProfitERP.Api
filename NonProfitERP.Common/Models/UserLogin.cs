using System.ComponentModel.DataAnnotations;

namespace NonProfitERP.Common.Identity.Models
{
    public class UserLogin
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}