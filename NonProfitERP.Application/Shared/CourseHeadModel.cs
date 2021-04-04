using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;
using System;

namespace NonProfitERP.Application.Shared
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
