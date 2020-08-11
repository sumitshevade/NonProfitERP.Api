using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class PersonDisability : Entity
    {
        public PersonDisability()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Problem { get; set; }

        public string Detail { get; set; }

        public int? FromYear { get; set; }

        public int? ToYear { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        #endregion

    }
}
