using AutoMapper;
using NonProfitERP.Application.Mappings;
using System.Collections.Generic;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class DistrictModel : IMapFrom<District>
    {
        //public DistrictModel()
        //{
        //    PersonAddress = new HashSet<PersonAddress>();
        //    Taluka = new HashSet<Taluka>();
        //}

        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        //public virtual State State { get; set; }
        //public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<Taluka> Taluka { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<District, DistrictModel>();
        }
    }
}
