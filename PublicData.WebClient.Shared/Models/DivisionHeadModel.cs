namespace PublicData.WebClient.Shared.Models
{
    public partial class DivisionHeadModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DivisionId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }
        public bool IsActive { get; set; }
    }
}
