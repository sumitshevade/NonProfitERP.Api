using System;

namespace PublicData.WebClient.Shared.Models
{
    public partial class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
