using System;
using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.Application.Shared
{
    public partial class ProgramModel : IMapFrom<Program>
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }

        public virtual Department Department { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Program, ProgramModel>();
        }
    }
}
