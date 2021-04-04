using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
