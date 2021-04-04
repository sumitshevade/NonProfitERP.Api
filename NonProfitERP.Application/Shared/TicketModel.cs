using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class TicketModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public int TicketCount { get; set; }

        public virtual Event Event { get; set; }
        public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ticket, TicketModel>();
        }
    }
}
