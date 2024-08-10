using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;
using System;
using System.Collections.Generic;

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
