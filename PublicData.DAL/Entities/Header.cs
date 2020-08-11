using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Header : Entity
    {
        public Header()
        {
            #region Generated Constructor
            Details = new HashSet<Detail>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Detail> Details { get; set; }

        #endregion

    }
}
