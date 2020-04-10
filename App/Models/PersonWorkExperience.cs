using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Person work experience.
    /// </summary>
    public class PersonWorkExperience : BaseClass
    {
        /// <summary>
        /// Reference for person .
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for person's working industry.
        /// </summary>
        [Required, Display(Name = "Industry")]
        public int IndustryId { get; set; }

        /// <summary>
        /// Reference for person's work type.
        /// </summary>
        [Display(Name = "Work Type")]
        public int? WorkTypeId { get; set; }

        /// <summary>
        /// Person's working company name.
        /// </summary>
        [Display(Name = "Company Name"), StringLength(50)]
        public string CompanyName { get; set; }

        /// <summary>
        /// What that person is doing at work.
        /// </summary>
        [Display(Name = "Actual Work"), StringLength(50)]
        public string ActualWork { get; set; }

        /// <summary>
        /// From when the person started working at?
        /// </summary>
        [Display(Name = "From Year"), Range(1900, 2100)]
        public int? FromYear { get; set; }

        /// <summary>
        /// Until when person worked at?
        /// </summary>
        [Display(Name = "To Year"), Range(1900, 2100)]
        public int? ToYear { get; set; }

        /// <summary>
        /// Person's work experience details.
        /// </summary>
        [Display(Name = "Description"), StringLength(500)]
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Detail Industry { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail WorkType { get; set; }

        #endregion
    }
}
