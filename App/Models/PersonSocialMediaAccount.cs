using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonSocialMediaAccount
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail AccountType { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail TypeOfUser { get; set; }
    }
}
