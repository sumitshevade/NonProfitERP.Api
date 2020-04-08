using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// List of states.
    /// </summary>
    public class State : BaseClass
    {
        public State()
        {
            Cities = new HashSet<City>();
            PersonAddresses = new HashSet<PersonAddress>();
        }

        /// <summary>
        /// State name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reference for country.
        /// </summary>
        public int? CountryId { get; set; }

        #region --- Relationships ---
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        #endregion
    }
}
