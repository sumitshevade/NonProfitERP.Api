using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonFamilyDetailsRepository : Repository<PersonFamilyDetail>, IPersonFamilyDetailsRepository
    {
        public PersonFamilyDetailsRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
