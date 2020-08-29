namespace PublicData.WebClient.Shared.Models
{
    public partial class PersonHealthDetailModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }
        public bool IsActive { get; set; }
    }
}
