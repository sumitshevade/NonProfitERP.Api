using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person disability list.
    /// </summary>
    public class PersonDisability : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Problem that person have.
        /// </summary>
        [Required, Display(Name = "Disability"), StringLength(50)]
        public string Problem { get; set; }

        /// <summary>
        /// Details about the problem.
        /// </summary>
        [Display(Name = "Description"), StringLength(250)]
        public string Detail { get; set; }

        /// <summary>
        /// From when this problem started.
        /// </summary>
        [Display(Name = "From Year"), Range(1900, 2100)]
        public int? FromYear { get; set; }

        /// <summary>
        /// When this problem ended.
        /// </summary>
        [Display(Name = "To Year"), Range(1900, 2100)]
        public int? ToYear { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
