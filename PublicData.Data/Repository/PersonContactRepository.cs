using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonContactRepository : Repository<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
