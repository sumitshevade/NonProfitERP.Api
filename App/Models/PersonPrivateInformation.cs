using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class PersonPrivateInformation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool MaritalStatus { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsOwnBicycle { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? ParentalStatusId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Details Caste { get; set; }
        public virtual Details ParentalStatus { get; set; }
        public virtual Person Person { get; set; }
        public virtual Details Religion { get; set; }
    }
}
