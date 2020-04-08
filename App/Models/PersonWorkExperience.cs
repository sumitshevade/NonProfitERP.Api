using System;
using System.Collections.Generic;

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
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for person's working industry.
        /// </summary>
        public int IndustryId { get; set; }

        /// <summary>
        /// Reference for person's work type.
        /// </summary>
        public int? WorkTypeId { get; set; }

        /// <summary>
        /// Person's working company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// What that person is doing at work.
        /// </summary>
        public string ActualWork { get; set; }

        /// <summary>
        /// From when the person started working at?
        /// </summary>
        public int? FromYear { get; set; }

        /// <summary>
        /// Until when person worked at?
        /// </summary>
        public int? ToYear { get; set; }

        /// <summary>
        /// Person's work experience details.
        /// </summary>
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Detail Industry { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail WorkType { get; set; }

        #endregion
    }
}
