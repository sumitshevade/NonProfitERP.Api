using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class UniversityModel : IMapFrom<University>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<University, UniversityModel>();
        }
    }
}
