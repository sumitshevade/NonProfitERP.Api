using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonHobbyFavoriteRepository : Repository<PersonHobbyFavorite>, IPersonHobbyFavoriteRepository
    {
        public PersonHobbyFavoriteRepository(PublicDataContext context) : base(context)
        {
        }
    }

}
