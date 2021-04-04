using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.DAL.Entities;
using System;

namespace PublicData.Application.Shared
{
    public partial class PersonPrivateInformationModel : IMapFrom<PersonPrivateInformation>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int MaritalStatus { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsOwnBicycle { get; set; }
        public int? ReligionId { get; set; }
        public string OtherReligion { get; set; }
        public int? CasteId { get; set; }
        public string OtherCaste { get; set; }
        public int? CategoryId { get; set; }
        public string OtherCategory { get; set; }
        public int? ParentalStatusId { get; set; }
        public string OtherParentalStatus { get; set; }
        public bool IsAlive { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public bool IsActive { get; set; }

        public virtual Detail Caste { get; set; }
        public virtual Detail Category { get; set; }
        public virtual Detail ParentalStatus { get; set; }
        public virtual Detail Religion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonPrivateInformation, PersonPrivateInformationModel>();
        }
    }
}
