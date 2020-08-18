using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class City : Entity
    {
        public City()
        {
            #region Generated Constructor
            PersonAddresses = new HashSet<PersonAddress>();
            Universities = new HashSet<University>();
            #endregion
        }

        #region Generated Properties

        public int? StateId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<University> Universities { get; set; }

        #endregion

    }
}
