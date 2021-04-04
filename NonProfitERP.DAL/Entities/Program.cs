using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class Program : Entity
    {
        public Program()
        {
            #region Generated Constructor
            Courses = new HashSet<Course>();
            PersonPrograms = new HashSet<PersonProgram>();
            SubPersonSubPrograms = new HashSet<PersonSubProgram>();
            SubPrograms = new HashSet<SubProgram>();
            #endregion
        }

        #region Generated Properties

        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ContactNo { get; set; }

        public string EmailId { get; set; }

        public string WebLink { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Course> Courses { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<PersonProgram> PersonPrograms { get; set; }

        public virtual ICollection<PersonSubProgram> SubPersonSubPrograms { get; set; }

        public virtual ICollection<SubProgram> SubPrograms { get; set; }

        #endregion

    }
}
