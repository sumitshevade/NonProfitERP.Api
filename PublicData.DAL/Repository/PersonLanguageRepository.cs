using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonLanguageRepository : Repository<PersonLanguage>, IPersonLanguageRepository
    {
        public PersonLanguageRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
