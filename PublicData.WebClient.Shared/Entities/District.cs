namespace PublicData.WebClient.Shared.Entities
{
    public partial class District
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
