using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class TalukaRepository : Repository<Taluka>, ITalukaRepository
    {
        public TalukaRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
