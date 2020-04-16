using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// University list.
    /// </summary>
    public class University : BaseClass
    {
        /// <summary>
        /// University name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reference for City, from where university belongs.
        /// </summary>
        [Display(Name = "City")]
        public int CityId { get; set; }

        #region --- Relationships ---
        public virtual City City { get; set; }

        #endregion
    }
}
