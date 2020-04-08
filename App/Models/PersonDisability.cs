using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person disability list.
    /// </summary>
    public class PersonDisability : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Problem that person have.
        /// </summary>
        public string Problem { get; set; }

        /// <summary>
        /// Details about the problem.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// From when this problem started.
        /// </summary>
        public int? FromYear { get; set; }

        /// <summary>
        /// When this problem ended.
        /// </summary>
        public int? ToYear { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
