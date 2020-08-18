using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class Program
    {
        public Program()
        {
            #region Generated Constructor
            ProgramAttendances = new HashSet<ProgramAttendance>();
            Tickets = new HashSet<Ticket>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        #endregion

    }
}
