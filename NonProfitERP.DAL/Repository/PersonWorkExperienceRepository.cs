using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonWorkExperienceRepository : Repository<PersonWorkExperience>, IPersonWorkExperienceRepository
    {
        public PersonWorkExperienceRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
