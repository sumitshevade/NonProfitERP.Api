using System;
using System.Collections.Generic;

namespace PublicData.WebClient.Models
{
    public class People
    {
        //public People()
        //{
        //    DepartmentHeads = new HashSet<DepartmentHead>();
        //    DivisionHeads = new HashSet<DivisionHead>();
        //    PersonAchievements = new HashSet<PersonAchievement>();
        //    PersonAddresses = new HashSet<PersonAddress>();
        //    PersonContacts = new HashSet<PersonContact>();
        //    PersonDisabilities = new HashSet<PersonDisability>();
        //    PersonEducations = new HashSet<PersonEducation>();
        //    PersonFamilyDetails = new HashSet<PersonFamilyDetails>();
        //    PersonHealthDetails = new HashSet<PersonHealthDetails>();
        //    PersonHobbyFavorites = new HashSet<PersonHobbyFavorite>();
        //    PersonLanguages = new HashSet<PersonLanguage>();
        //    PersonPrivateInformations = new HashSet<PersonPrivateInformation>();
        //    PersonSocialMediaAccounts = new HashSet<PersonSocialMediaAccount>();
        //    PersonWorkExperiences = new HashSet<PersonWorkExperience>();
        //    ProgramAttendances = new HashSet<ProgramAttendance>();
        //    Tickets = new HashSet<Ticket>();
        //}

        public int Id { get; set; }
        public string LoginId { get; set; }
        public int PersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public string LongText { get; set; }
        public string Keywords { get; set; }
        public bool IsWorker { get; set; }
        public int WorkFrequencyId { get; set; }
        public DateTime JoiningDate { get; set; }
        public int JoinedAsId { get; set; }
        public int CountryId { get; set; }

        //public virtual Country Country { get; set; }
        //public virtual Details JoinedAs { get; set; }
        //public virtual Details PersonType { get; set; }
        //public virtual Details WorkFrequency { get; set; }
        //public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }
        //public virtual ICollection<DivisionHead> DivisionHeads { get; set; }
        //public virtual ICollection<PersonAchievement> PersonAchievements { get; set; }
        //public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        //public virtual ICollection<PersonContact> PersonContacts { get; set; }
        //public virtual ICollection<PersonDisability> PersonDisabilities { get; set; }
        //public virtual ICollection<PersonEducation> PersonEducations { get; set; }
        //public virtual ICollection<PersonFamilyDetails> PersonFamilyDetails { get; set; }
        //public virtual ICollection<PersonHealthDetails> PersonHealthDetails { get; set; }
        //public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }
        //public virtual ICollection<PersonLanguage> PersonLanguages { get; set; }
        //public virtual ICollection<PersonPrivateInformation> PersonPrivateInformations { get; set; }
        //public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccounts { get; set; }
        //public virtual ICollection<PersonWorkExperience> PersonWorkExperiences { get; set; }
        //public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }
        //public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
