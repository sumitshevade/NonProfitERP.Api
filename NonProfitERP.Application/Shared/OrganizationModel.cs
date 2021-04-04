using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class OrganizationModel : IMapFrom<Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string WebLink { get; set; }
        public string ContactNo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationModel>();
        }
    }
}
