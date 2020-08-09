using System;
using AutoMapper;
using PublicData.Application.Mappings;
using System.Collections.Generic;

namespace PublicData.Application.Shared
{
    using DAL.Entities;

    public class DivisionModel : IMapFrom<Division>
    {
        public DivisionModel()
        {
            DivisionHead = new HashSet<DivisionHead>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<DivisionHead> DivisionHead { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Division, DivisionModel>();
        }
    }
}
