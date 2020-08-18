using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class DivisionHeadRepository : Repository<DivisionHead>, IDivisionHeadRepository
    {
        public DivisionHeadRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
