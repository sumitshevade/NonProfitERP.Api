using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonHobbyFavoriteRepository : Repository<PersonHobbyFavorite>, IPersonHobbyFavoriteRepository
    {
        public PersonHobbyFavoriteRepository(PublicDataContext context) : base(context)
        {
        }
    }

}
