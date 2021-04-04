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

        public int EventId { get; set; }

        public int PersonId { get; set; }

        public int TicketCount { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Event Event { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
