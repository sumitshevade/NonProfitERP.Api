using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
