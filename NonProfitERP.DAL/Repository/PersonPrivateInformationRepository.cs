using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonPrivateInformationRepository : Repository<PersonPrivateInformation>, IPersonPrivateInformationRepository
    {
        public PersonPrivateInformationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
