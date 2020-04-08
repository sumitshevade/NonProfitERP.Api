using System;
using System.Collections.Generic;

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
        public double? Iq { get; set; }

        /// <summary>
        /// Person wake up timing.
        /// </summary>
        public double? WakeUpTiming { get; set; }

        /// <summary>
        /// Person sleep timing.
        /// </summary>
        public double? SleepTiming { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
