using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class PersonEducation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? SchoolId { get; set; }
        public int? FromStdId { get; set; }
        public int? ToStdId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }
        public int? UniversityBoardId { get; set; }
        public int? DegreeId { get; set; }
        public int? CourseId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Details Course { get; set; }
        public virtual Details Degree { get; set; }
        public virtual Details FromStd { get; set; }
        public virtual Person Person { get; set; }
        public virtual Details School { get; set; }
        public virtual Details ToStd { get; set; }
        public virtual Details UniversityBoard { get; set; }
    }
}
