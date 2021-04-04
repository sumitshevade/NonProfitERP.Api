using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
