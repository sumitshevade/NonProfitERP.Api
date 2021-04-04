using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
