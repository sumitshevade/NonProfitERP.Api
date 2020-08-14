using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class State : Entity
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

        public string Name { get; set; }
        public int? CountryId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<City> Cities { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<District> Districts { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        #endregion

    }
}
