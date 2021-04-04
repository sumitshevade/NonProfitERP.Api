using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonDisabilityRepository : Repository<PersonDisability>, IPersonDisabilityRepository
    {
        public PersonDisabilityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
