using AutoMapper;
using System.Collections.Generic;
using PublicData.Application.Mappings;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

    public partial class StateModel : IMapFrom<State>
    {
        public StateModel()
        {
            City = new HashSet<City>();
            District = new HashSet<District>();
            PersonAddress = new HashSet<PersonAddress>();
        }

        public string Name { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<District> District { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryModel>();
        }
    }
}
