using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person social media accounts.
    /// </summary>
    public class PersonSocialMediaAccount : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for person's social account type.
        /// </summary>
        [Required, Display(Name = "Account Type")]
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Person's social media account link.
        /// </summary>
        [StringLength(250)]
        public string Link { get; set; }

        /// <summary>
        /// Reference for frequency of the use. e.g. Regular use, Rare use, Moderate use.
        /// </summary>
        [Required, Display(Name = "Use Frequency")]
        public int TypeOfUserId { get; set; }

        #region --- Relationships ---
        public virtual Detail AccountType { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail TypeOfUser { get; set; }

        #endregion
    }
}
