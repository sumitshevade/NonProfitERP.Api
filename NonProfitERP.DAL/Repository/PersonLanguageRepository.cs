using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonLanguageRepository : Repository<PersonLanguage>, IPersonLanguageRepository
    {
        public PersonLanguageRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
