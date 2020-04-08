using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    /// <summary>
    /// Common fields added in this abstract class.
    /// </summary>
    public abstract class BaseClass
    {
        /// <summary>
        /// Unique, auto-generated, primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Record created by id.
        /// </summary>
        public string CreatedById { get; set; }

        /// <summary>
        /// Record creation date & time, auto set.
        /// </summary>
        public DateTime CreatedAt { get { return DateTime.Now; } set { } }

        /// <summary>
        /// Record updated by id.
        /// </summary>
        public string UpdatedById { get; set; }

        /// <summary>
        /// Record updation date & time, auto set.
        /// </summary>
        public DateTime? UpdatedAt { get { return DateTime.Now; } set { } }

        /// <summary>
        /// Record deleted by id.
        /// </summary>
        public string DeletedById { get; set; }

        /// <summary>
        /// Record deleted date & time, auto set.
        /// </summary>
        public DateTime? DeletedAt { get { return DateTime.Now; } set { } }
    }
}
