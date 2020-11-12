namespace PublicData.WebClient.Shared.Models
{
    public partial class ProgramAttendanceModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProgramId { get; set; }
        public bool IsActive { get; set; }
    }
}
