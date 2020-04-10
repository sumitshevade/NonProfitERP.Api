using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required, Display(Name = "Department")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Division name
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Division works at location.
        /// </summary>
        [StringLength(250)]
        public string Address { get; set; }

        /// <summary>
        /// Division started on date.
        /// </summary>
        [Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Description about division
        /// </summary>
        [Display(Name = "Description"), StringLength(500)]
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Department Department { get; set; }
        public virtual ICollection<DivisionHead> DivisionHeads { get; set; }

        #endregion
    }
}
