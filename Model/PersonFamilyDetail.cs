using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person family details.
    /// </summary>
    public class PersonFamilyDetail : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for relation.
        /// </summary>
        [Display(Name = "Relation")]
        public int? RelationId { get; set; }

        /// <summary>
        /// Reference for course.
        /// </summary>
        [Display(Name = "Course")]
        public int? CourseId { get; set; }

        /// <summary>
        /// Person family member disability.
        /// </summary>
        [Display(Name = "Any Disability"), StringLength(100)]
        public string AnyDisability { get; set; }

        /// <summary>
        /// Person family member firstname.
        /// </summary>
        [Required, Display(Name = "First Name"), StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Person family member middlename.
        /// </summary>
        [Display(Name = "Middle Name"), StringLength(50)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Person family member lastname.
        /// </summary>
        [Required, Display(Name = "Last Name"), StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Person family member birthdate.
        /// </summary>
        [Display(Name = "Birth Date"), DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Person family member mobile no.
        /// </summary>
        [Display(Name = "Mobile No"), StringLength(15)]
        public string MobileNo { get; set; }

        /// <summary>
        /// Person family member email id.
        /// </summary>
        [Display(Name = "Email"), StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Person family member company name (if any).
        /// </summary>
        [Display(Name = "Company Name"), StringLength(50)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Person family member school name (if any).
        /// </summary>
        [Display(Name = "School Name"), StringLength(50)]
        public string SchoolName { get; set; }

        /// <summary>
        /// Person family member monthly income
        /// </summary>
        [Display(Name = "Monthly Income"), Range(0, 1000000)]
        public double? MonthlyIncome { get; set; }

        #region --- Relationships ---
        public virtual Detail Course { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail Relation { get; set; }

        #endregion
    }
}
