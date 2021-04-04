using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        public DetailRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
