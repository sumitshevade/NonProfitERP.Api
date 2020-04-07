using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonLanguage
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public bool IsMotherTongue { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail Language { get; set; }
        public virtual People Person { get; set; }
    }
}
