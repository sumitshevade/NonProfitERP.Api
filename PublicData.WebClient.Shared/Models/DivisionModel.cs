using System;

namespace PublicData.WebClient.Shared.Models
{
    public partial class DivisionModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
