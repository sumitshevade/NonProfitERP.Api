using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Data.Entities;

namespace PublicData.Application.Shared
{
    public class PersonHealthDetailModel : IMapFrom<PersonHealthDetail>
    {
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }

        public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonHealthDetail, PersonHealthDetailModel>();
        }
    }
}
