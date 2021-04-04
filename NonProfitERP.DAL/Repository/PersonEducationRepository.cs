using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonEducationRepository : Repository<PersonEducation>, IPersonEducationRepository
    {
        public PersonEducationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
