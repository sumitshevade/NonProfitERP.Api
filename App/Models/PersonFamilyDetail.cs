using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person family details.
    /// </summary>
    public class PersonFamilyDetail : BaseClass
    {
        /// <summary>
        /// Reference for person.
        /// </summary>
        public int? PersonId { get; set; }

        /// <summary>
        /// Reference for relation.
        /// </summary>
        public int? RelationId { get; set; }

        /// <summary>
        /// Reference for course.
        /// </summary>
        public int? CourseId { get; set; }

        /// <summary>
        /// Person family member disability.
        /// </summary>
        public string AnyDisability { get; set; }

        /// <summary>
        /// Person family member firstname.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person family member middlename.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Person family member lastname.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Person family member birthdate.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Person family member mobile no.
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// Person family member email id.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Person family member company name (if any).
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Person family member school name (if any).
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// Person family member monthly income
        /// </summary>
        public double? MonthlyIncome { get; set; }

        #region --- Relationships ---
        public virtual Detail Course { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail Relation { get; set; }

        #endregion
    }
}
