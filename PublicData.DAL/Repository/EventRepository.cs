using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
