using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonFamilyDetailsRepository : Repository<PersonFamilyDetail>, IPersonFamilyDetailsRepository
    {
        public PersonFamilyDetailsRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
