using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Data.Entities;

namespace PublicData.Application.Shared
{
    public class PersonContactModel : IMapFrom<PersonContact>
    {
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }

        public virtual Detail ContactType { get; set; }
        public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonContact, PersonContactModel>();
        }
    }
}
