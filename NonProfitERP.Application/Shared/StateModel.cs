using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;
using System.Collections.Generic;

namespace NonProfitERP.Application.Shared
{
    public partial class StateModel : IMapFrom<State>
    {
        public StateModel()
        {
            City = new HashSet<City>();
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<District> District { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<State, StateModel>();
        }
    }
}
