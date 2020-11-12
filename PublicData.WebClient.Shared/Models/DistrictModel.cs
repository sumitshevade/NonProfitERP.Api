namespace PublicData.WebClient.Shared.Models
{
    public partial class DistrictModel
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
