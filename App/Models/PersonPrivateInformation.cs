using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonPrivateInformation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool MaritalStatus { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsOwnBicycle { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? ParentalStatusId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail Caste { get; set; }
        public virtual Detail ParentalStatus { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail Religion { get; set; }
    }
}
