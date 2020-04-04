using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class PersonLanguage
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public bool IsMotherTongue { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Details Language { get; set; }
        public virtual Person Person { get; set; }
    }
}
