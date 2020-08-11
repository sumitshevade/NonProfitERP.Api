using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class ProgramAttendance : Entity
    {
        public ProgramAttendance()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int ProgramId { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        public virtual Program Program { get; set; }

        #endregion

    }
}
