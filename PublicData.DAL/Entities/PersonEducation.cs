using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class PersonEducation : Entity
    {
        public PersonEducation()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int? SchoolId { get; set; }

        public string OtherSchool { get; set; }

        public int? FromStdId { get; set; }

        public int? ToStdId { get; set; }

        public int? MediumId { get; set; }

        public string OtherMedium { get; set; }

        public int FromYear { get; set; }

        public int? ToYear { get; set; }

        public int? UniversityBoardId { get; set; }

        public string OtherUniversityBoard { get; set; }

        public int? DegreeId { get; set; }

        public string OtherDegree { get; set; }

        public int? CourseId { get; set; }

        public string OtherCourse { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail CourseDetail { get; set; }

        public virtual Detail DegreeDetail { get; set; }

        public virtual Detail FromStdDetail { get; set; }

        public virtual Detail MediumDetail { get; set; }

        public virtual Person Person { get; set; }

        public virtual School School { get; set; }

        public virtual Detail ToStdDetail { get; set; }

        public virtual Detail UniversityBoardDetail { get; set; }

        #endregion

    }
}
