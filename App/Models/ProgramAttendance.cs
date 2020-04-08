using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Program attendance details.
    /// </summary>
    public class ProgramAttendance : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for program.
        /// </summary>
        public int ProgramId { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }
        public virtual Program Program { get; set; }

        #endregion
    }
}
