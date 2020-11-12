namespace PublicData.WebClient.Shared.Models
{
    public partial class TicketModel
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int PersonId { get; set; }
        public int TicketCount { get; set; }
        public bool IsActive { get; set; }
    }
}
