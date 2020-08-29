namespace PublicData.WebClient.Shared.Entities
{
    public partial class DivisionHead
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DivisionId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }
        public bool IsActive { get; set; }
    }
}
