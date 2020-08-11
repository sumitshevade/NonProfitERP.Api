using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Person : Entity
    {
        public Person()
        {
            #region Generated Constructor
            DepartmentHeads = new HashSet<DepartmentHead>();
            DivisionHeads = new HashSet<DivisionHead>();
            PersonAchievements = new HashSet<PersonAchievement>();
            PersonAddresses = new HashSet<PersonAddress>();
            PersonContacts = new HashSet<PersonContact>();
            PersonDisabilities = new HashSet<PersonDisability>();
            PersonEducations = new HashSet<PersonEducation>();
            PersonFamilyDetails = new HashSet<PersonFamilyDetail>();
            PersonHealthDetails = new HashSet<PersonHealthDetail>();
            PersonHobbyFavorites = new HashSet<PersonHobbyFavorite>();
            PersonLanguages = new HashSet<PersonLanguage>();
            PersonPrivateInformations = new HashSet<PersonPrivateInformation>();
            PersonSocialMediaAccounts = new HashSet<PersonSocialMediaAccount>();
            PersonWorkExperiences = new HashSet<PersonWorkExperience>();
            ProgramAttendances = new HashSet<ProgramAttendance>();
            Tickets = new HashSet<Ticket>();
            #endregion
        }

        #region Generated Properties
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

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsAlive { get; set; }

        public DateTime? DateOfExpiry { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Country Country { get; set; }

        public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }

        public virtual ICollection<DivisionHead> DivisionHeads { get; set; }

        public virtual ICollection<PersonAchievement> PersonAchievements { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        public virtual ICollection<PersonContact> PersonContacts { get; set; }

        public virtual ICollection<PersonDisability> PersonDisabilities { get; set; }

        public virtual ICollection<PersonEducation> PersonEducations { get; set; }

        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetails { get; set; }

        public virtual ICollection<PersonHealthDetail> PersonHealthDetails { get; set; }

        public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }

        public virtual ICollection<PersonLanguage> PersonLanguages { get; set; }

        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformations { get; set; }

        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccounts { get; set; }

        public virtual ICollection<PersonWorkExperience> PersonWorkExperiences { get; set; }

        public virtual ICollection<ProgramAttendance> ProgramAttendances { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual Detail TypeDetail { get; set; }

        public virtual Detail WorkFrequencyDetail { get; set; }

        #endregion

    }
}
