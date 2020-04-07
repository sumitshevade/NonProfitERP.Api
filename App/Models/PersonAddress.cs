using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonAddress
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
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
        public int? LocalityClass { get; set; }
        public int? ResidentialStatus { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Detail HomeStatus { get; set; }
        public virtual Detail LocalityClassNavigation { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail ResidentialStatusNavigation { get; set; }
        public virtual State State { get; set; }
    }
}
