using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        public DetailRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
