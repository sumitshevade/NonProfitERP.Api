namespace PublicData.WebClient.Shared.Entities
{
    public partial class Taluka
    {
        public int Id { get; set; }
        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
