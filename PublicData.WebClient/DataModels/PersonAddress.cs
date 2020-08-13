using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class PersonAddress
    {
        public PersonAddress()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
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

        public string ZipCode { get; set; }

        public int? FromYear { get; set; }

        public int? ToYear { get; set; }

        public int? RoomsInHome { get; set; }

        public bool IsGovtBuildUp { get; set; }

        public int? HomeStatusId { get; set; }

        public int? LocalityClassId { get; set; }

        public int? ResidentialStatusId { get; set; }

        public int? ResidentialAreaId { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual District District { get; set; }

        public virtual Detail HomeStatusDetail { get; set; }

        public virtual Detail LocalityClassDetail { get; set; }

        public virtual Person Person { get; set; }

        public virtual Detail ResidentialAreaDetail { get; set; }

        public virtual Detail ResidentialStatusDetail { get; set; }

        public virtual State State { get; set; }

        public virtual Taluka Taluka { get; set; }

        #endregion

    }
}
