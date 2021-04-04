using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.DAL.Entities;
using System;

namespace NonProfitERP.Application.Shared
{
    public partial class SubProgramModel : IMapFrom<SubProgram>
    {
        public int Id { get; set; }
        public int? ProgramId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string WebLink { get; set; }
        public string LongText { get; set; }

        public virtual Program Program { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SubProgram, SubProgramModel>();
        }
    }
}
