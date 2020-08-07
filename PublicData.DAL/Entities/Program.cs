using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Program : Entity
    {
        public Program()
        {
            ProgramAttendance = new HashSet<ProgramAttendance>();
            Ticket = new HashSet<Ticket>();
        }

        public string Name { get; set; }

        public virtual ICollection<ProgramAttendance> ProgramAttendance { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
