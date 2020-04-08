using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Division head list.
    /// </summary>
    public class DivisionHead : BaseClass
    {
        /// <summary>
        /// Person reference for division head.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Division reference for head.
        /// </summary>
        public int DivisionId { get; set; }

        /// <summary>
        /// From when this person started working as a division head.
        /// </summary>
        public int FromYear { get; set; }

        /// <summary>
        /// Until when this person was a division head.
        /// </summary>
        public int? ToYear { get; set; }

        #region --- Relationships ---
        public virtual Division Division { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
