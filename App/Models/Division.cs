using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Division comes under department.
    /// </summary>
    public class Division : BaseClass
    {
        public Division()
        {
            DivisionHeads = new HashSet<DivisionHead>();
        }

        /// <summary>
        /// Department reference for Division.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Division name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Division works at location.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Division started on date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Description about division
        /// </summary>
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Department Department { get; set; }
        public virtual ICollection<DivisionHead> DivisionHeads { get; set; }

        #endregion
    }
}
