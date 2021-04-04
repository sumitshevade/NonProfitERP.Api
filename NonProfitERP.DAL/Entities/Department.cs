using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class Department : Entity
    {
        public Department()
        {
            #region Generated Constructor
            Courses = new HashSet<Course>();
            PersonDepartments = new HashSet<PersonDepartment>();
            Programs = new HashSet<Program>();
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ContactNo { get; set; }

        public string EmailId { get; set; }

        public string WebLink { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<PersonDepartment> PersonDepartments { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        #endregion

    }
}
