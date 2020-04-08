using System;
using System.Collections.Generic;

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
        public int PersonId { get; set; }

        /// <summary>
        /// Contact Type. e.g. Mobile No, Email, etc.
        /// </summary>
        public int? ContactType { get; set; }

        /// <summary>
        /// Any extra details.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Is this default contact info.
        /// </summary>
        public bool IsDefault { get; set; }

        #region --- Relationships ---
        public virtual Detail ContactTypeNavigation { get; set; }
        public virtual People Person { get; set; }
        
        #endregion
    }
}
