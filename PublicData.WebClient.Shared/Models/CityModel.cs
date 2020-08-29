namespace PublicData.WebClient.Shared.Models
{
    public partial class CityModel
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
