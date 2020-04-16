using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
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
        /// Header title.
        /// </summary>
        [Required, StringLength(50)]
        public string Title { get; set; }

        #region --- Relationships ---
        public virtual ICollection<Detail> Details { get; set; }

        #endregion
    }
}
