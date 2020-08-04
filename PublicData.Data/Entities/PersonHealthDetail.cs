namespace PublicData.Data.Entities
{
    public partial class PersonHealthDetail : Entity
    {
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }

        public virtual Person Person { get; set; }
    }
}
