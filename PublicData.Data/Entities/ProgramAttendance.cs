namespace PublicData.Data.Entities
{
    public partial class ProgramAttendance : Entity
    {
        public int PersonId { get; set; }
        public int ProgramId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Program Program { get; set; }
    }
}
