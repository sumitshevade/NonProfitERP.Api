using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Department head list
    /// </summary>
    public class DepartmentHead : BaseClass
    {
        /// <summary>
        /// Reference for the person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Department reference for the head.
        /// </summary>
        [Required, Display(Name = "Department")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// From when this person started working as a department head.
        /// </summary>
        [Required, Display(Name = "From Year"), Range(1900, 2100)]
        public int FromYear { get; set; }

        /// <summary>
        /// Until when this person was department head.
        /// </summary>
        [Display(Name = "To Year"), Range(1900, 2100)]
        public int? ToYear { get; set; }

        #region --- Relationships ---
        public virtual Department Department { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
