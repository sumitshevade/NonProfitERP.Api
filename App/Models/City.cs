using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// City list
    /// </summary>
    public class City : BaseClass
    {
        public City()
        {
            PersonAddresses = new HashSet<PersonAddress>();
            Universities = new HashSet<University>();
        }

        /// <summary>
        /// Reference for the state.
        /// </summary>
        [Required, Display(Name = "State")]
        public int? StateId { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        #region --- Relationships ---
        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<University> Universities { get; set; }

        #endregion
    }
}
