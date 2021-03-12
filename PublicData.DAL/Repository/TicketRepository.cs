using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
