using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class State
    {
        public State()
        {
            #region Generated Constructor
            Cities = new HashSet<City>();
            Districts = new HashSet<District>();
            PersonAddresses = new HashSet<PersonAddress>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<City> Cities { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<District> Districts { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        #endregion

    }
}
