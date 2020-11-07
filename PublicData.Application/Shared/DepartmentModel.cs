using System;
using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class DepartmentModel : IMapFrom<Department>
    {
        public DepartmentModel()
        {
            Division = new HashSet<Division>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }

        public virtual ICollection<Division> Division { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentModel>();
        }
    }
}
