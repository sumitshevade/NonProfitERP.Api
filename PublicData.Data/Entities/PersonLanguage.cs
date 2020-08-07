namespace PublicData.DAL.Entities
{
    public partial class PersonLanguage : Entity
    {
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public string OtherLanguage { get; set; }
        public bool IsMotherTongue { get; set; }

        public virtual Detail Language { get; set; }
        public virtual Person Person { get; set; }
    }
}
