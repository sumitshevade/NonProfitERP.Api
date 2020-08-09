using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

    public partial class DistrictModel : IMapFrom<District>
    {
        public DistrictModel()
        {
            PersonAddress = new HashSet<PersonAddress>();
            Taluka = new HashSet<Taluka>();
        }

        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<Taluka> Taluka { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<District, DistrictModel>();
        }
    }
}
