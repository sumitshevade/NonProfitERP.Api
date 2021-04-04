using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
