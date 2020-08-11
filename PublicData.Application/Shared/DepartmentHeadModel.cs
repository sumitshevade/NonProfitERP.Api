using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class DepartmentHeadModel : IMapFrom<DepartmentHead>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public virtual Department Department { get; set; }
        public virtual Person Person { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentHead, DepartmentHeadModel>();
        }
    }
}
