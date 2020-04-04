using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PanNo { get; set; }
        public bool IsNasscomRegistered { get; set; }
        public string LongText { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
