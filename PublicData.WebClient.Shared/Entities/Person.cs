using System;

namespace PublicData.WebClient.Shared.Entities
{
    public partial class Person
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public int PersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public string LongText { get; set; }
        public string Keywords { get; set; }
        public bool IsWorker { get; set; }
        public int WorkFrequencyId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? JoinedAsId { get; set; }
        public int? CountryId { get; set; }
        public bool IsAlive { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public bool IsActive { get; set; }
    }
}
