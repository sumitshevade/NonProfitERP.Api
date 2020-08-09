using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

    public partial class TalukaModel : IMapFrom<Taluka>
    {
        public TalukaModel()
        {
            PersonAddress = new HashSet<PersonAddress>();
        }

        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Taluka, TalukaModel>();
        }
    }
}
