namespace PublicData.WebClient.Shared.Models
{
    public partial class StateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
