using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class CityModel : IMapFrom<City>
    {
        //public CityModel()
        //{
        //    PersonAddress = new HashSet<PersonAddress>();
        //    University = new HashSet<University>();
        //}

        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }

        public virtual State State { get; set; }
        //public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        //public virtual ICollection<University> University { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityModel>();
        }
    }
}
