namespace PublicData.WebClient.Shared.Entities
{
    public partial class City
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
