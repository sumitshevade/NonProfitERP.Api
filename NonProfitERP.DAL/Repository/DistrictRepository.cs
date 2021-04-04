using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
