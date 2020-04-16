using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person hobby and favorites.
    /// </summary>
    public class PersonHobbyFavorite : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Person hobby or favorite option selection.
        /// </summary>
        [Display(Name = "Hobby / Favorite")]
        public int? HobbyFavoriteId { get; set; }

        /// <summary>
        /// Person hobby or favorite details.
        /// </summary>
        [Display(Name = "Description"), StringLength(500)]
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Detail HobbyFavorite { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
