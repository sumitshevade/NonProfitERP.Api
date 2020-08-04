using System;

namespace PublicData.Data.Entities
{
    public partial class PersonHobbyFavorite : Entity
    {
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }

        public virtual Detail HobbyFavorite { get; set; }
        public virtual Person Person { get; set; }
    }
}
