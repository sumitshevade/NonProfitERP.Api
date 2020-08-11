using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class CountryModel : IMapFrom<Country>
    {
        public CountryModel()
        {
            //Person = new HashSet<Person>();
            //PersonAddress = new HashSet<PersonAddress>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Person> Person { get; set; }
        //public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<State> State { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryModel>();
        }
    }
}
