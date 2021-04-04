using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
