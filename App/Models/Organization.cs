using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Organization information. Will be useful for SaaS.
    /// </summary>
    public class Organization : BaseClass
    {
        public Organization()
        {
            Departments = new HashSet<Department>();
            Headers = new HashSet<Header>();
            People = new HashSet<People>();
            Programs = new HashSet<Program>();
        }

        /// <summary>
        /// Organization name.
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Organization address.
        /// </summary>
        [StringLength(250)]
        public string Address { get; set; }

        /// <summary>
        /// Organization Pan card no.
        /// </summary>
        [StringLength(15), Display(Name = "PAN No")]
        public string PanNo { get; set; }

        /// <summary>
        /// Is organization registered as Nasscom user?
        /// </summary>
        [Display(Name = "NASSCOM Registered?")]
        public bool IsNasscomRegistered { get; set; }

        /// <summary>
        /// Organization description.
        /// </summary>
        [Display(Name = "Description"), StringLength(500)]
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Header> Headers { get; set; }
        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        
        #endregion
    }
}
