using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class District : Entity
    {
        public District()
        {
            #region Generated Constructor
            PersonAddresses = new HashSet<PersonAddress>();
            Talukas = new HashSet<Taluka>();
            #endregion
        }

        #region Generated Properties

        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Taluka> Talukas { get; set; }

        #endregion

    }
}
