using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class EventModel : IMapFrom<Event>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventModel>();
        }
    }
}
