using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Ticket : Entity
    {
        public Ticket()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int ProgramId { get; set; }
        public int PersonId { get; set; }
        public int TicketCount { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        public virtual Program Program { get; set; }

        #endregion

    }
}
