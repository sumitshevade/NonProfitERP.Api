using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class TalukaModel : IMapFrom<Taluka>
    {
        public int Id { get; set; }
        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        public virtual District District { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Taluka, TalukaModel>();
        }
    }
}
