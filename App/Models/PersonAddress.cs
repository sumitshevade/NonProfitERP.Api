using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Person address.
    /// </summary>
    public class PersonAddress : BaseClass
    {
        /// <summary>
        /// Reference for person address.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Reference for country.
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Reference for state.
        /// </summary>
        public int? StateId { get; set; }

        /// <summary>
        /// Reference for city.
        /// </summary>
        public int? CityId { get; set; }

        /// <summary>
        /// Is this permanent address?
        /// </summary>
        public bool IsPermanent { get; set; }

        /// <summary>
        /// Road name.
        /// </summary>
        public string RoadName { get; set; }

        /// <summary>
        /// Address Line 1.
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// Address Line 2.
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// Zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// From when started staying at this place?
        /// </summary>
        public int? FromYear { get; set; }

        /// <summary>
        /// Until when stayed at this place.
        /// </summary>
        public int? ToYear { get; set; }

        /// <summary>
        /// Rooms in your home?
        /// </summary>
        public int? RoomsInHome { get; set; }

        /// <summary>
        /// Is govt built up home?
        /// </summary>
        public bool IsGovtBuildUp { get; set; }

        /// <summary>
        /// Home status. e.g. Own, Rented, Relatives Free, Relatived Rented, etc.
        /// </summary>
        public int? HomeStatusId { get; set; }

        /// <summary>
        /// Class of the area. e.g. High class, medium class, low class, slum, etc.
        /// </summary>
        public int? LocalityClass { get; set; }

        /// <summary>
        /// Residential status. e.g. Bunglow, Chowl, Wada, Society, etc.
        /// </summary>
        public int? ResidentialStatus { get; set; }

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
