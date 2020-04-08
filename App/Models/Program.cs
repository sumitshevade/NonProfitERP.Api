using System;
using System.Collections.Generic;

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
        /// Reference for organization.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Program name.
        /// </summary>
        public string Name { get; set; }

        #region --- Relationships ---
        public virtual Organization Organization { get; set; }
        public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }

        #endregion
    }
}
