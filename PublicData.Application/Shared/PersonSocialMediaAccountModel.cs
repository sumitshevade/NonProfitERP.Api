using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public class PersonSocialMediaAccountModel : IMapFrom<PersonSocialMediaAccount>
    {
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string OtherAccountType { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }

        public virtual Detail AccountType { get; set; }
        public virtual Person Person { get; set; }
        public virtual Detail TypeOfUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonSocialMediaAccount, PersonSocialMediaAccountModel>();
        }
    }
}
