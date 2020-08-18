using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class PersonLanguageModel : IMapFrom<PersonLanguage>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public string OtherLanguage { get; set; }
        public bool IsMotherTongue { get; set; }

        public virtual Detail Language { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonLanguage, PersonLanguageModel>();
        }
    }
}
