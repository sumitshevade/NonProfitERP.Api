using AutoMapper;
using System.Collections.Generic;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
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
