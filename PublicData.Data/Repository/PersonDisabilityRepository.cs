using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonDisabilityRepository : Repository<PersonDisability>, IPersonDisabilityRepository
    {
        public PersonDisabilityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
