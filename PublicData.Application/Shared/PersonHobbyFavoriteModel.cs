using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class PersonHobbyFavoriteModel : IMapFrom<PersonHobbyFavorite>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }

        public virtual Detail HobbyFavorite { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonHobbyFavorite, PersonHobbyFavoriteModel>();
        }
    }
}
