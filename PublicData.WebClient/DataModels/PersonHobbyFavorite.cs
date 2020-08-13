using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class PersonHobbyFavorite
    {
        public PersonHobbyFavorite()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int? HobbyFavoriteId { get; set; }

        public string LongText { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail HobbyFavoriteDetail { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
