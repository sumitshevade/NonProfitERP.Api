using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonContactRepository : Repository<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
