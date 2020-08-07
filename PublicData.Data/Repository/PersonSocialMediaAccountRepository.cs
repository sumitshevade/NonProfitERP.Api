using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonSocialMediaAccountRepository : Repository<PersonSocialMediaAccount>, IPersonSocialMediaAccountRepository
    {
        public PersonSocialMediaAccountRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
