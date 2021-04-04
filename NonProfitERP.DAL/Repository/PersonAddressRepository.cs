using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonAddressRepository : Repository<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
