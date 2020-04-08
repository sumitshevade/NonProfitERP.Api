using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person hobby and favorites.
    /// </summary>
    public class PersonHobbyFavorite : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Person hobby or favorite option selection.
        /// </summary>
        public int? HobbyFavoriteId { get; set; }

        /// <summary>
        /// Person hobby or favorite details.
        /// </summary>
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual Detail HobbyFavorite { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
