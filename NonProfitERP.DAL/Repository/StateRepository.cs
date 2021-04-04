using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
