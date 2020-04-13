using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Organization arranged program list.
    /// </summary>
    public class Program : BaseClass
    {
        public Program()
        {
            ProgramAttendances = new HashSet<ProgramAttendance>();
        }

        /// <summary>
        /// Program name.
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        #region --- Relationships ---
        public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }

        #endregion
    }
}
