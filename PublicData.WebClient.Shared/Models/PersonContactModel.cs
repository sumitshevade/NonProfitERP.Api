namespace PublicData.WebClient.Shared.Models
{
    public partial class PersonContactModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }

        public DetailModel ContactTypeDetail { get; set; }
    }
}
