using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public class PersonDisabilityModel : IMapFrom<PersonDisability>
    {
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }

        public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonDisability, PersonDisabilityModel>();
        }
    }
}
