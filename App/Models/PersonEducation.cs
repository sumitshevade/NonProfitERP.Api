using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person education details.
    /// </summary>
    public class PersonEducation : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for school.
        /// </summary>
        public int? SchoolId { get; set; }

        /// <summary>
        /// Reference for from standard.
        /// </summary>
        public int? FromStdId { get; set; }

        /// <summary>
        /// Reference for to standard.
        /// </summary>
        public int? ToStdId { get; set; }

        /// <summary>
        /// From year.
        /// </summary>
        public int FromYear { get; set; }

        /// <summary>
        /// To year.
        /// </summary>
        public int? ToYear { get; set; }

        /// <summary>
        /// Reference for university or board
        /// </summary>
        public int? UniversityBoardId { get; set; }

        /// <summary>
        /// Reference for degree.
        /// </summary>
        public int? DegreeId { get; set; }

        /// <summary>
        /// Reference for course.
        /// </summary>
        public int? CourseId { get; set; }

        #region --- Relationships ---
        public virtual Detail Course { get; set; }
        public virtual Detail Degree { get; set; }
        public virtual Detail FromStd { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail School { get; set; }
        public virtual Detail ToStd { get; set; }
        public virtual Detail UniversityBoard { get; set; }

        #endregion
    }
}
