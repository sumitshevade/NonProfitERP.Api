using Repository.Contracts;
using Model;
using Repository.Implementations;

namespace Repository.Implementations
{
    public class HeaderRepository : GenericRepositoy<Header>, IHeaderRepository
    {
        public HeaderRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
