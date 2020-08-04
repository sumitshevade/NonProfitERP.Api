namespace PublicData.Data.Entities
{
    public partial class PersonDisability : Entity
    {
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }

        public virtual Person Person { get; set; }
    }
}
