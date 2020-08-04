using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonAddressRepository : Repository<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
