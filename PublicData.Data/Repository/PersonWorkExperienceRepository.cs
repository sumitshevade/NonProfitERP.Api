using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonWorkExperienceRepository : Repository<PersonWorkExperience>, IPersonWorkExperienceRepository
    {
        public PersonWorkExperienceRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
