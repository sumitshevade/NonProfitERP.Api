using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PublicData.Application.Shared
{
    public partial class CourseModel : IMapFrom<Course>
    {
        public int? DepartmentId { get; set; }
        public int? ProgramId { get; set; }
        public int? SubProgramId { get; set; }
        public int? HeadId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string LongText { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<CourseHead> CourseHeads { get; set; }
        public virtual Department Department { get; set; }
        public virtual Person HeadPerson { get; set; }
        public virtual Program Program { get; set; }
        public virtual SubProgram SubProgram { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseModel>();
        }
    }
}
