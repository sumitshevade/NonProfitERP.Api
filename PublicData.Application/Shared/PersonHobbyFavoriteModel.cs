using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Data.Entities;

namespace PublicData.Application.Shared
{
    public class PersonHobbyFavoriteModel : IMapFrom<PersonHobbyFavorite>
    {
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }

        public virtual Detail HobbyFavorite { get; set; }
        public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonHobbyFavorite, PersonHobbyFavoriteModel>();
        }
    }
}
