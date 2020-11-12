namespace PublicData.WebClient.Shared.Entities
{
    public partial class PersonContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }

        public virtual Detail ContactTypeDetail { get; set; }
    }
}
