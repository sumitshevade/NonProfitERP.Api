using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonFamilyDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string SchoolName { get; set; }
        public double? MonthlyIncome { get; set; }
        public int? PersonId { get; set; }
        public int? RelationId { get; set; }
        public int? CourseId { get; set; }
        public string AnyDisability { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail Course { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail Relation { get; set; }
    }
}
