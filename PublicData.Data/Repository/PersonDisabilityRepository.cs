using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonDisabilityRepository : Repository<PersonDisability>, IPersonDisabilityRepository
    {
        public PersonDisabilityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
