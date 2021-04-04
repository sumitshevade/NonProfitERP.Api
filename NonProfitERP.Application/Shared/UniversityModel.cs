using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class UniversityModel : IMapFrom<University>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        //public virtual City City { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<University, UniversityModel>();
        }
    }
}
