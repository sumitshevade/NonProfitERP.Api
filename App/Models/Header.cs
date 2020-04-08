using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Header-Detail class.
    /// </summary>
    public class Header : BaseClass
    {
        public Header()
        {
            Details = new HashSet<Detail>();
        }

        /// <summary>
        /// Organization reference for header.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Header title.
        /// </summary>
        public string Title { get; set; }

        #region --- Relationships ---
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Detail> Details { get; set; }

        #endregion
    }
}
