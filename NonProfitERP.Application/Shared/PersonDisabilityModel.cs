using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class PersonDisabilityModel : IMapFrom<PersonDisability>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }

        //public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonDisability, PersonDisabilityModel>();
        }
    }
}
