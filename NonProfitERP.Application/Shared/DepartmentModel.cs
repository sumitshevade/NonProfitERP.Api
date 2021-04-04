using System;
using AutoMapper;
using NonProfitERP.Application.Mappings;
using System.Collections.Generic;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class DepartmentModel : IMapFrom<Department>
    {
        public DepartmentModel()
        {
            Programs = new HashSet<Program>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentModel>();
        }
    }
}
