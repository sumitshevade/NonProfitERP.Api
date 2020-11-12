namespace PublicData.WebClient.Shared.Models
{
    public partial class PersonDisabilityModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public bool IsActive { get; set; }
    }
}
