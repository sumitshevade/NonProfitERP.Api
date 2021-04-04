using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class PersonSocialMediaAccountModel : IMapFrom<PersonSocialMediaAccount>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string OtherAccountType { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }

        public virtual Detail AccountType { get; set; }
        public virtual Detail TypeOfUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonSocialMediaAccount, PersonSocialMediaAccountModel>();
        }
    }
}
