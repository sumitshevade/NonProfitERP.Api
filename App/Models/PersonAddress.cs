using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class PersonAddress
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
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Details HomeStatus { get; set; }
        public virtual Details LocalityClassNavigation { get; set; }
        public virtual Person Person { get; set; }
        public virtual Details ResidentialStatusNavigation { get; set; }
        public virtual State State { get; set; }
    }
}
