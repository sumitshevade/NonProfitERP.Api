using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Organization
    {
        public Organization()
        {
            Departments = new HashSet<Department>();
            Headers = new HashSet<Header>();
            People = new HashSet<People>();
            Programs = new HashSet<Program>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PanNo { get; set; }
        public bool IsNasscomRegistered { get; set; }
        public string LongText { get; set; }

        [Display()]
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Header> Headers { get; set; }
        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}
