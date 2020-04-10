using System;
using System.ComponentModel.DataAnnotations;

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
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Person achievement title.
        /// </summary>
        [Required, StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Achievement award given by. e.g. Govt, School, University, etc.
        /// </summary>
        [Display(Name = "Given By"), StringLength(100)]
        public string GivenBy { get; set; }

        /// <summary>
        /// Format of the achievement award. e.g. Book, Money, et.
        /// </summary>
        [StringLength(50)]
        public string Format { get; set; }

        /// <summary>
        /// Why person got the achievement award?
        /// </summary>
        [StringLength(50)]
        public string Reason { get; set; }

        /// <summary>
        /// Achievement award date.
        /// </summary>
        [Display(Name = "Received Date")]
        public DateTime? ReceivedDate { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
