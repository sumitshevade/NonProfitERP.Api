using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class PersonContact
    {
        public PersonContact()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int? ContactTypeId { get; set; }

        public string Detail { get; set; }

        public bool IsDefault { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail ContactTypeDetail { get; set; }

        //public virtual Person Person { get; set; }

        #endregion

    }
}
