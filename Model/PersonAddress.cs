using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Person address.
    /// </summary>
    public class PersonAddress : BaseClass
    {
        /// <summary>
        /// Reference for person address.
        /// </summary>
        [Required, Display(Name = "Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for country.
        /// </summary>
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Reference for state.
        /// </summary>
        [Display(Name = "State")]
        public int? StateId { get; set; }

        /// <summary>
        /// Reference for city.
        /// </summary>
        [Display(Name = "City")]
        public int? CityId { get; set; }

        /// <summary>
        /// Is this permanent address?
        /// </summary>
        [Display(Name = "Is Permanent?")]
        public bool IsPermanent { get; set; }

        /// <summary>
        /// Road name.
        /// </summary>
        [Display(Name = "Road Name"), StringLength(25)]
        public string RoadName { get; set; }

        /// <summary>
        /// Address Line 1.
        /// </summary>
        [Display(Name = "Address Line 1"), StringLength(100)]
        public string Line1 { get; set; }

        /// <summary>
        /// Address Line 2.
        /// </summary>
        [Display(Name = "Address Line 2"), StringLength(100)]
        public string Line2 { get; set; }

        /// <summary>
        /// Zip code.
        /// </summary>
        [Display(Name = "Zip Code"), StringLength(10)]
        public string ZipCode { get; set; }

        /// <summary>
        /// From when started staying at this place?
        /// </summary>
        [Display(Name = "From Year"), Range(1900, 2100)]
        public int? FromYear { get; set; }

        /// <summary>
        /// Until when stayed at this place.
        /// </summary>
        [Display(Name = "To Year"), Range(1900, 2100)]
        public int? ToYear { get; set; }

        /// <summary>
        /// Rooms in your home?
        /// </summary>
        [Display(Name = "Rooms in Home"), Range(1, 6)]
        public int? RoomsInHome { get; set; }

        /// <summary>
        /// Is govt built up home?
        /// </summary>
        [Display(Name = "Is Govt Builtup?")]
        public bool IsGovtBuildUp { get; set; }

        /// <summary>
        /// Home status. e.g. Own, Rented, Relatives Free, Relatived Rented, etc.
        /// </summary>
        [Display(Name = "Home Status")]
        public int? HomeStatusId { get; set; }

        /// <summary>
        /// Class of the area. e.g. High class, medium class, low class, slum, etc.
        /// </summary>
        [Display(Name = "Locality Class")]
        public int? LocalityClassId { get; set; }

        /// <summary>
        /// Residential status. e.g. Bunglow, Chowl, Wada, Society, etc.
        /// </summary>
        [Display(Name = "Residential Status")]
        public int? ResidentialStatusId { get; set; }

        #region --- Relationships ---
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Detail HomeStatus { get; set; }
        public virtual Detail LocalityClassNavigation { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail ResidentialStatusNavigation { get; set; }
        public virtual State State { get; set; }

        #endregion
    }
}
