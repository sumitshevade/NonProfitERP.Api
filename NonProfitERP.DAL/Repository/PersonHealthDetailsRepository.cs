using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonHealthDetailsRepository : Repository<PersonHealthDetail>, IPersonHealthDetailsRepository
    {
        public PersonHealthDetailsRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
