using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonHealthDetailsRepository : Repository<PersonHealthDetail>, IPersonHealthDetailsRepository
    {
        public PersonHealthDetailsRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
