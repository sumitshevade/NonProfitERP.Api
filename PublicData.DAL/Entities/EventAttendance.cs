namespace PublicData.DAL.Entities
{
    public partial class EventAttendance : Entity
    {
        public EventAttendance()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int EventId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Event Event { get; set; }

        public virtual Person Person { get; set; }

        #endregion
    }
}
