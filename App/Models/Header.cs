using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [ScaffoldColumn(false)]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Header title.
        /// </summary>
        [Required, StringLength(50)]
        public string Title { get; set; }

        #region --- Relationships ---
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Detail> Details { get; set; }

        #endregion
    }
}
