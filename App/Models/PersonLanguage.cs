using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person languages.
    /// </summary>
    public class PersonLanguage : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for language.
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Is this language is mother tongue for person.
        /// </summary>
        public bool IsMotherTongue { get; set; }

        #region --- Relationships ---
        public virtual Detail Language { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
