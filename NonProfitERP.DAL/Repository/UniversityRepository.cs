using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
