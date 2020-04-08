using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person's achievement list.
    /// </summary>
    public class PersonAchievement : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int? PersonId { get; set; }

        /// <summary>
        /// Person achievement title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Achievement award given by. e.g. Govt, School, University, etc.
        /// </summary>
        public string GivenBy { get; set; }

        /// <summary>
        /// Format of the achievement award. e.g. Book, Money, et.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Why person got the achievement award?
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Achievement award date.
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
