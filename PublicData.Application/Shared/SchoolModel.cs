using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;

namespace PublicData.Application.Shared
{
    using DAL.Entities;
    
    public partial class SchoolModel : IMapFrom<School>
    {
        public SchoolModel()
        {
            PersonEducation = new HashSet<PersonEducation>();
        }

        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonContactNo { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? SchoolTypeId { get; set; }

        public virtual Detail SchoolType { get; set; }
        public virtual ICollection<PersonEducation> PersonEducation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<School, SchoolModel>();
        }
    }
}
