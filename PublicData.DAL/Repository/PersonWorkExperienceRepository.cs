using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonWorkExperienceRepository : Repository<PersonWorkExperience>, IPersonWorkExperienceRepository
    {
        public PersonWorkExperienceRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
