using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        public DetailRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
