namespace PublicData.WebClient.Shared.Models
{
    public partial class SchoolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonContactNo { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? SchoolTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
