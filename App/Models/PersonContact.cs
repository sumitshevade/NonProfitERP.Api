using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Person contact list.
    /// </summary>
    public class PersonContact : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Contact Type. e.g. Mobile No, Email, etc.
        /// </summary>
        [Required, Display(Name = "Contact Type")]
        public int? ContactTypeId { get; set; }

        /// <summary>
        /// Any extra details.
        /// </summary>
        [Display(Name = "Details"), StringLength(100)]
        public string Detail { get; set; }

        /// <summary>
        /// Is this default contact info.
        /// </summary>
        [Display(Name = "Is Default?")]
        public bool IsDefault { get; set; }

        #region --- Relationships ---
        public virtual Detail ContactTypeNavigation { get; set; }
        public virtual People Person { get; set; }
        
        #endregion
    }
}
