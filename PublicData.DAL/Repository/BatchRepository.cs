using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class BatchRepository : Repository<Batch>, IBatchRepository
    {
        public BatchRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
