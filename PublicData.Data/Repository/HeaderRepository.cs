using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class HeaderRepository : Repository<Header>, IHeaderRepository
    {
        public HeaderRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
