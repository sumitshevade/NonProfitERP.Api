using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Program
    {
        public Program()
        {
            ProgramAttendances = new HashSet<ProgramAttendance>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }
    }
}
