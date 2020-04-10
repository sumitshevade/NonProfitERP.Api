using System.ComponentModel.DataAnnotations;

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
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for school.
        /// </summary>
        [Display(Name = "School")]
        public int? SchoolId { get; set; }

        /// <summary>
        /// Reference for from standard.
        /// </summary>
        [Display(Name = "From Std")]
        public int? FromStdId { get; set; }

        /// <summary>
        /// Reference for to standard.
        /// </summary>
        [Display(Name = "To Std")]
        public int? ToStdId { get; set; }

        /// <summary>
        /// From year.
        /// </summary>
        [Display(Name = "From Year"), Range(1900, 2100)]
        public int FromYear { get; set; }

        /// <summary>
        /// To year.
        /// </summary>
        [Display(Name = "To Year"), Range(1900, 2100)]
        public int? ToYear { get; set; }

        /// <summary>
        /// Reference for university or board
        /// </summary>
        [Display(Name = "University / Board")]
        public int? UniversityBoardId { get; set; }

        /// <summary>
        /// Reference for degree.
        /// </summary>
        [Display(Name = "Degree")]
        public int? DegreeId { get; set; }

        /// <summary>
        /// Reference for course.
        /// </summary>
        [Display(Name = "Course")]
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
