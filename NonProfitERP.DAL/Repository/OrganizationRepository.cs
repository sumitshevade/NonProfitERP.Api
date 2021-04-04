using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
