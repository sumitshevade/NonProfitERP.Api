using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
