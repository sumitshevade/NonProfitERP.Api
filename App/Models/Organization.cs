using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Organization information. Will be useful for SaaS.
    /// </summary>
    public class Organization : BaseClass
    {
        public Organization()
        {
            Departments = new HashSet<Department>();
            Headers = new HashSet<Header>();
            People = new HashSet<People>();
            Programs = new HashSet<Program>();
        }

        /// <summary>
        /// Organization name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organization address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Organization Pan card no.
        /// </summary>
        public string PanNo { get; set; }

        /// <summary>
        /// Is organization registered as Nasscom user?
        /// </summary>
        public bool IsNasscomRegistered { get; set; }

        /// <summary>
        /// Organization description.
        /// </summary>
        public string LongText { get; set; }

        #region --- Relationships ---
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Header> Headers { get; set; }
        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<Program> Programs { get; set; }

        #endregion
    }
}
