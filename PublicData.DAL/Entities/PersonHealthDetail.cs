namespace PublicData.DAL.Entities
{
    public partial class PersonHealthDetail : Entity
    {
        public PersonHealthDetail()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public double? Iq { get; set; }

        public double? WakeUpTiming { get; set; }

        public double? SleepTiming { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        #endregion

    }
}
