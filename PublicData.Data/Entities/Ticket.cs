using System;

namespace PublicData.Data.Entities
{
    public partial class Ticket : Entity
    {
        public int ProgramId { get; set; }
        public int PersonId { get; set; }
        public int TicketCount { get; set; }

        public virtual Person Person { get; set; }
        public virtual Program Program { get; set; }
    }
}
