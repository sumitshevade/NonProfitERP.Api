namespace PublicData.WebClient.Shared.Models
{
    public partial class DetailModel
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Value { get; set; }
        public string ExtraField { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
