using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person private information.
    /// </summary>
    public class PersonPrivateInformation : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Person marital status.
        /// </summary>
        public bool MaritalStatus { get; set; }

        /// <summary>
        /// Person aadhar no.
        /// </summary>
        public string AadharCardNo { get; set; }

        /// <summary>
        /// Person have own bicycle?
        /// </summary>
        public bool IsOwnBicycle { get; set; }

        /// <summary>
        /// Reference for person's religion.
        /// </summary>
        public int? ReligionId { get; set; }

        /// <summary>
        /// Reference for person's caste.
        /// </summary>
        public int? CasteId { get; set; }

        /// <summary>
        /// Reference for person's parental status.
        /// </summary>
        public int? ParentalStatusId { get; set; }

        #region --- Relationships ---
        public virtual Detail Caste { get; set; }
        public virtual Detail ParentalStatus { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail Religion { get; set; }

        #endregion
    }
}
