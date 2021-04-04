using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonEducationRepository : Repository<PersonEducation>, IPersonEducationRepository
    {
        public PersonEducationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
