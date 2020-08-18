using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Program : Entity
    {
        public Program()
        {
            #region Generated Constructor
            ProgramAttendances = new HashSet<ProgramAttendance>();
            Tickets = new HashSet<Ticket>();
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        #endregion

    }
}
