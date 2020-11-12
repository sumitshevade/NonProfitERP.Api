using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonContactRepository : Repository<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
