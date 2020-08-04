using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
