using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonEducation
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
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail Course { get; set; }
        public virtual Detail Degree { get; set; }
        public virtual Detail FromStd { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail School { get; set; }
        public virtual Detail ToStd { get; set; }
        public virtual Detail UniversityBoard { get; set; }
    }
}
