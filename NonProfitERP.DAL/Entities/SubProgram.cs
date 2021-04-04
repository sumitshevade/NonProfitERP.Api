using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class SubProgram : Entity
    {
        public SubProgram()
        {
            #region Generated Constructor
            Courses = new HashSet<Course>();
            #endregion
        }

        #region Generated Properties

        public int? ProgramId { get; set; }

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

        public virtual Program Program { get; set; }

        #endregion

    }
}
