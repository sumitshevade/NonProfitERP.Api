using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonFamilyDetailsRepository : Repository<PersonFamilyDetail>, IPersonFamilyDetailsRepository
    {
        public PersonFamilyDetailsRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
