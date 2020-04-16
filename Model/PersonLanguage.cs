using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person languages.
    /// </summary>
    public class PersonLanguage : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for language.
        /// </summary>
        [Required (ErrorMessage = "Please select the language."), Display(Name = "Language")]
        public int LanguageId { get; set; }

        /// <summary>
        /// Is this language is mother tongue for person.
        /// </summary>
        [Display(Name = "Is Mothertongue")]
        public bool IsMotherTongue { get; set; }

        #region --- Relationships ---
        public virtual Detail Language { get; set; }
        public virtual People Person { get; set; }

        #endregion
    }
}
