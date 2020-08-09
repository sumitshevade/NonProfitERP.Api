using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
