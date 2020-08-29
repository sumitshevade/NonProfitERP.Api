using System;

namespace PublicData.WebClient.Shared.Entities
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
