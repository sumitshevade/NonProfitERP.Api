using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;
using System;

namespace PublicData.Application.Shared
{
    public partial class BatchModel : IMapFrom<Batch>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Year { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string LongText { get; set; }

        public virtual Course Course { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Batch, BatchModel>();
        }
    }
}
