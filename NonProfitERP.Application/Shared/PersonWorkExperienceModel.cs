using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class PersonWorkExperienceModel : IMapFrom<PersonWorkExperience>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int IndustryId { get; set; }
        public string OtherIndustry { get; set; }
        public int? WorkTypeId { get; set; }
        public string OtherWorkType { get; set; }
        public int? StatusId { get; set; }
        public string OtherStatus { get; set; }
        public string CompanyName { get; set; }
        public string ActualWork { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string LongText { get; set; }

        public virtual Detail Industry { get; set; }
        public virtual Detail Status { get; set; }
        public virtual Detail WorkType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonWorkExperience, PersonWorkExperienceModel>();
        }
    }
}
