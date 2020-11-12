namespace PublicData.WebClient.Shared.Entities
{
    public partial class PersonHobbyFavorite
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
