using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class TalukaRepository : Repository<Taluka>, ITalukaRepository
    {
        public TalukaRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
