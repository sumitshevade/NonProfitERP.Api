using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class University : Entity
    {
        public University()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual City City { get; set; }

        #endregion

    }
}
