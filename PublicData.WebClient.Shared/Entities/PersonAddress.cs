using System.ComponentModel.DataAnnotations;

namespace PublicData.WebClient.Shared.Entities
{
    public partial class PersonAddress
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string OtherCity { get; set; }
        public int? TalukaId { get; set; }
        public string OtherTaluka { get; set; }
        public int? DistrictId { get; set; }
        public string OtherDistrict { get; set; }
        public string Village { get; set; }
        public bool IsPermanent { get; set; }
        public string RoadName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Range(1900, 2021, ErrorMessage = "Year must be between 1900 and 2021")]
        public int? FromYear { get; set; }
        
        [Range(1900, 2021, ErrorMessage = "Year must be between 1900 and 2021")]
        public int? ToYear { get; set; }

        [Range(1, 9, ErrorMessage = "Rooms in home must be between 1 and 9")]
        public int? RoomsInHome { get; set; }
        public bool IsGovtBuildUp { get; set; }
        public int? HomeStatusId { get; set; }
        public int? LocalityClassId { get; set; }
        public int? ResidentialStatusId { get; set; }
        public int? ResidentialAreaId { get; set; }
        public bool IsActive { get; set; }
    }
}
