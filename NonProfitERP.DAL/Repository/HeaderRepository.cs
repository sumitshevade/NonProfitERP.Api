using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class HeaderRepository : Repository<Header>, IHeaderRepository
    {
        public HeaderRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
