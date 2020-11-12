using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
