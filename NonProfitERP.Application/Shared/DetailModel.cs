using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class DetailModel : IMapFrom<Detail>
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Name { get; set; }
        public string ExtraField { get; set; }

        public virtual Header Header { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Detail, DetailModel>();
        }
    }
}
