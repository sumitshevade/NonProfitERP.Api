namespace PublicData.WebClient.Shared.Entities
{
    public partial class PersonLanguage
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public string OtherLanguage { get; set; }
        public bool IsMotherTongue { get; set; }
        public bool IsActive { get; set; }
    }
}
