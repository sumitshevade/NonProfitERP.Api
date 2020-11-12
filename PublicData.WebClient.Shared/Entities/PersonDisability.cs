namespace PublicData.WebClient.Shared.Entities
{
    public partial class PersonDisability
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public bool IsActive { get; set; }
    }
}
