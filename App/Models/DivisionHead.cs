using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Division head list.
    /// </summary>
    public class DivisionHead : BaseClass
    {
        /// <summary>
        /// Person reference for division head.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Division reference for head.
        /// </summary>
        [Required, Display(Name = "Division")]
        public int DivisionId { get; set; }

        /// <summary>
        /// From when this person started working as a division head.
        /// </summary>
        [Display(Name = "From Year"), DataType(DataType.Date)]
        public int FromYear { get; set; }

        /// <summary>
        /// Until when this person was a division head.
        /// </summary>
        [Display(Name = "To Year"), DataType(DataType.Date)]
        public int? ToYear { get; set; }

        #region --- Relationships ---
        public virtual Division Division { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
