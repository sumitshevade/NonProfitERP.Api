using AutoMapper;
using PublicData.Application.Mappings;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

    public partial class UniversityModel : IMapFrom<University>
    {
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<University, UniversityModel>();
        }
    }
}
