using System;

namespace PublicData.DAL.Entities
{
    public partial class PersonFamilyDetail : Entity
    {
        public PersonFamilyDetail()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string SchoolName { get; set; }
        public double? MonthlyIncome { get; set; }
        public int PersonId { get; set; }
        public int? RelationId { get; set; }
        public string OtherRelation { get; set; }
        public int? CourseId { get; set; }
        public string OtherCourse { get; set; }
        public string AnyDisability { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail CourseDetail { get; set; }

        public virtual Person Person { get; set; }

        public virtual Detail RelationDetail { get; set; }

        #endregion

    }
}
