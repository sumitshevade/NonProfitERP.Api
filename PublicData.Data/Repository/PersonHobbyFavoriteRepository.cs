using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonHobbyFavoriteRepository : Repository<PersonHobbyFavorite>, IPersonHobbyFavoriteRepository
    {
        public PersonHobbyFavoriteRepository(PublicDataContext context) : base(context)
        {
        }
    }

}
