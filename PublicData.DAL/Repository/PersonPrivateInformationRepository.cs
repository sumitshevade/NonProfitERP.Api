using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonPrivateInformationRepository : Repository<PersonPrivateInformation>, IPersonPrivateInformationRepository
    {
        public PersonPrivateInformationRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
