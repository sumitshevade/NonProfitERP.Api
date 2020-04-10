using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Country list.
    /// </summary>
    public class Country : BaseClass
    {
        public Country()
        {
            People = new HashSet<People>();
            PersonAddresses = new HashSet<PersonAddress>();
            States = new HashSet<State>();
        }

        /// <summary>
        /// Country name.
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        #region --- Relationships ---
        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<State> States { get; set; }

        #endregion
    }
}
