using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;
using System.Collections.Generic;

namespace NonProfitERP.Application.Shared
{
    public partial class HeaderModel : IMapFrom<Header>
    {
        public HeaderModel()
        {
            Detail = new HashSet<Detail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Detail> Detail { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Header, HeaderModel>();
        }
    }
}
