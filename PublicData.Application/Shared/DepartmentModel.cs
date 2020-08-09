using System;
using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

    public partial class DepartmentModel : IMapFrom<Department>
    {
        public DepartmentModel()
        {
            DepartmentHead = new HashSet<DepartmentHead>();
            Division = new HashSet<Division>();
        }

        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }

        public virtual ICollection<DepartmentHead> DepartmentHead { get; set; }
        public virtual ICollection<Division> Division { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentModel>();
        }
    }
}
