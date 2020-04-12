using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Department list.
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
        [ScaffoldColumn(false)]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Department name.
        /// </summary>
        [Required, StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Department started date.
        /// </summary>
        [Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Description about department.
        /// </summary>
        [Display(Name = "Description"), StringLength(500)]
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }

        #endregion
    }
}
