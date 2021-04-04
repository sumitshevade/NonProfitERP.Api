using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Event : Entity
    {
        public Event()
        {
            #region Generated Constructor
            EventAttendances = new HashSet<EventAttendance>();
            Tickets = new HashSet<Ticket>();
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<EventAttendance> EventAttendances { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        #endregion
    }
}
