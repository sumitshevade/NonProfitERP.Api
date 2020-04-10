using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Person health details.
    /// </summary>
    public class PersonHealthDetail : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Person height.
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// Person weight.
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// Person IQ.
        /// </summary>
        [Display(Name = "IQ")]
        public double? Iq { get; set; }

        /// <summary>
        /// Person wake up timing.
        /// </summary>
        [Display(Name = "Wake-up Time"), Range(00.00, 23.59)]
        public double? WakeUpTiming { get; set; }

        /// <summary>
        /// Person sleep timing.
        /// </summary>
        [Display(Name = "Sleep Time"), Range(00.00, 23.59)]
        public double? SleepTiming { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
