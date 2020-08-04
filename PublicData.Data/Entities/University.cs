namespace PublicData.Data.Entities
{
    public partial class University : Entity
    {
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
