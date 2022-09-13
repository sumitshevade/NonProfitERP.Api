using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NonProfitERP.Common.Security.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
    }
}