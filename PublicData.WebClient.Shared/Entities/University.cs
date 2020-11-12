namespace PublicData.WebClient.Shared.Entities
{
    public partial class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
    }
}
