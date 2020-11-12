namespace PublicData.WebClient.Shared.Entities
{
    public partial class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
