using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for program.
        /// </summary>
        [Required, Display(Name = "Program")]
        public int ProgramId { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }
        public virtual Program Program { get; set; }

        #endregion
    }
}
