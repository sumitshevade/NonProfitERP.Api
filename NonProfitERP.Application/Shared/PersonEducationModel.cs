using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class PersonEducationModel : IMapFrom<PersonEducation>
    {
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

        public virtual Detail Course { get; set; }
        public virtual Detail Degree { get; set; }
        public virtual Detail FromStd { get; set; }
        public virtual Detail Medium { get; set; }
        public virtual School School { get; set; }
        public virtual Detail ToStd { get; set; }
        public virtual University UniversityBoard { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonEducation, PersonEducationModel>();
        }
    }
}
