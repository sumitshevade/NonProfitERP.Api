using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class SchoolModel : IMapFrom<School>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonContactNo { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? SchoolTypeId { get; set; }

        public virtual Detail SchoolType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<School, SchoolModel>();
        }
    }
}
