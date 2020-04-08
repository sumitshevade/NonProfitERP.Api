using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person social media accounts.
    /// </summary>
    public class PersonSocialMediaAccount : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for person's social account type.
        /// </summary>
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Person's social media account link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Reference for frequency of the use. e.g. Regular use, Rare use, Moderate use.
        /// </summary>
        public int TypeOfUserId { get; set; }

        #region --- Relationships ---
        public virtual Detail AccountType { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail TypeOfUser { get; set; }

        #endregion
    }
}
