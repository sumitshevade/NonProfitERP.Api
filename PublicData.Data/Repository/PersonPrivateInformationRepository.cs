using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonPrivateInformationRepository : Repository<PersonPrivateInformation>, IPersonPrivateInformationRepository
    {
        public PersonPrivateInformationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
