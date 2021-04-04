using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class PersonHealthDetailModel : IMapFrom<PersonHealthDetail>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonHealthDetail, PersonHealthDetailModel>();
        }
    }
}
