using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonHealthDetailsRepository : Repository<PersonHealthDetail>, IPersonHealthDetailsRepository
    {
        public PersonHealthDetailsRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
