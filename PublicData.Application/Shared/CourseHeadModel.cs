using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;
using System;

namespace PublicData.Application.Shared
{
    public partial class CourseHeadModel : IMapFrom<CourseHead>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseHead, CourseHeadModel>();
        }
    }
}
