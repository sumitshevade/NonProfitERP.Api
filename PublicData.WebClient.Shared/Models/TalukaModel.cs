namespace PublicData.WebClient.Shared.Models
{
    public partial class TalukaModel
    {
        public int Id { get; set; }
        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
