using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person private information.
    /// </summary>
    public class PersonPrivateInformation : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Person marital status.
        /// </summary>
        [Display(Name = "Marital Status")]
        public bool MaritalStatus { get; set; }

        /// <summary>
        /// Person aadhar no.
        /// </summary>
        [Display(Name = "Aadhar Card No"), StringLength(15)]
        public string AadharCardNo { get; set; }

        /// <summary>
        /// Person have own bicycle?
        /// </summary>
        [Display(Name = "Is Own Bicycle?")]
        public bool IsOwnBicycle { get; set; }

        /// <summary>
        /// Reference for person's religion.
        /// </summary>
        [Display(Name = "Religion")]
        public int? ReligionId { get; set; }

        /// <summary>
        /// Reference for person's caste.
        /// </summary>
        [Display(Name = "Caste")]
        public int? CasteId { get; set; }

        /// <summary>
        /// Reference for person's parental status.
        /// </summary>
        [Display(Name = "Parental Status")]
        public int? ParentalStatusId { get; set; }

        #region --- Relationships ---
        public virtual Detail Caste { get; set; }
        public virtual Detail ParentalStatus { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail Religion { get; set; }

        #endregion
    }
}
