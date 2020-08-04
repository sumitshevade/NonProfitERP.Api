using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonEducationRepository : Repository<PersonEducation>, IPersonEducationRepository
    {
        public PersonEducationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
