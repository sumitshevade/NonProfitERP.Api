using System;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Data.Entities;

namespace PublicData.Application.Shared
{
    public class PersonFamilyDetailModel : IMapFrom<PersonFamilyDetail>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string SchoolName { get; set; }
        public double? MonthlyIncome { get; set; }
        public int PersonId { get; set; }
        public int? RelationId { get; set; }
        public string OtherRelation { get; set; }
        public int? CourseId { get; set; }
        public string OtherCourse { get; set; }
        public string AnyDisability { get; set; }

        public virtual Detail Course { get; set; }
        public virtual Person Person { get; set; }
        public virtual Detail Relation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonFamilyDetail, PersonFamilyDetailModel>();
        }
    }
}
