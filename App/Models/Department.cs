using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Department list
    /// </summary>
    public class Department : BaseClass
    {
        public Department()
        {
            DepartmentHeads = new HashSet<DepartmentHead>();
            Divisions = new HashSet<Division>();
        }

        /// <summary>
        /// Organization reference for department.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Department name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Department started date
        /// </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Description about department
        /// </summary>
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Organization Organization { get; set; }
        public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }

        #endregion
    }
}
