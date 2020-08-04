using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class HeaderRepository : Repository<Header>, IHeaderRepository
    {
        public HeaderRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
