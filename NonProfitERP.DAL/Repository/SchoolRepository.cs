using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
