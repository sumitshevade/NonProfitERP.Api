namespace PublicData.WebClient.Shared.Entities
{
    public partial class ProgramAttendance
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProgramId { get; set; }
        public bool IsActive { get; set; }
    }
}
