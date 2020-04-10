using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Program ticket list.
    /// </summary>
    public class Ticket : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        #region --- Relationships ---
        public virtual People Person { get; set; }

        #endregion
    }
}
