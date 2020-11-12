namespace PublicData.WebClient.Shared.Entities
{
    public partial class Detail
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Value { get; set; }
        public string ExtraField { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
