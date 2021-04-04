using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class PersonContactModel : IMapFrom<PersonContact>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }

        public virtual Detail ContactTypeDetail { get; set; }
        //public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonContact, PersonContactModel>();
        }
    }
}
