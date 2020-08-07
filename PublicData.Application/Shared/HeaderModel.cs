using AutoMapper;
using System.Collections.Generic;
using PublicData.Application.Mappings;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

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
