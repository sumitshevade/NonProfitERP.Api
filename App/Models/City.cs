using System;
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
        /// City exists in the state.
        /// </summary>
        public int? StateId { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string Name { get; set; }

        #region --- Relationships ---
        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<University> Universities { get; set; }

        #endregion
    }
}
