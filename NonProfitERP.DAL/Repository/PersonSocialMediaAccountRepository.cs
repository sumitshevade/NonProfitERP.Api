using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonSocialMediaAccountRepository : Repository<PersonSocialMediaAccount>, IPersonSocialMediaAccountRepository
    {
        public PersonSocialMediaAccountRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
