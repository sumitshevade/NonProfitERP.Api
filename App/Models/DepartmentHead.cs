using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Department head list
    /// </summary>
    public class DepartmentHead : BaseClass
    {
        /// <summary>
        /// A person who is the head of the department.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Department reference for the head.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// From when this person started working as a department head.
        /// </summary>
        public int FromYear { get; set; }

        /// <summary>
        /// Until when this person was department head.
        /// </summary>
        public int? ToYear { get; set; }

        #region --- Relationships ---
        public virtual Department Department { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
