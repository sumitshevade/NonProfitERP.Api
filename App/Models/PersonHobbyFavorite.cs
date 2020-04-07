using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonHobbyFavorite
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail HobbyFavorite { get; set; }
        public virtual People Person { get; set; }
    }
}
