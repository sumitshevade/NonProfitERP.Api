using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonSocialMediaAccountRepository : Repository<PersonSocialMediaAccount>, IPersonSocialMediaAccountRepository
    {
        public PersonSocialMediaAccountRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
