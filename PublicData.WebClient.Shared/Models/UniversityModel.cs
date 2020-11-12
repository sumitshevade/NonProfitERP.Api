namespace PublicData.WebClient.Shared.Models
{
    public partial class UniversityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
    }
}
