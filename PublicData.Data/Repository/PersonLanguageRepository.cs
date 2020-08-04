using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonLanguageRepository : Repository<PersonLanguage>, IPersonLanguageRepository
    {
        public PersonLanguageRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
