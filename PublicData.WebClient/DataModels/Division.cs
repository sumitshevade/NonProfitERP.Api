using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class Division
    {
        public Division()
        {
            #region Generated Constructor
            DivisionHeads = new HashSet<DivisionHead>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public string LongText { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Department Department { get; set; }

        public virtual ICollection<DivisionHead> DivisionHeads { get; set; }

        #endregion

    }
}
