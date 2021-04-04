using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class Person : Entity
    {
        public Person()
        {
            #region Generated Constructor
            CourseHeads = new HashSet<CourseHead>();
            EventAttendances = new HashSet<EventAttendance>();
            HeadCourses = new HashSet<Course>();
            PersonAchievements = new HashSet<PersonAchievement>();
            PersonAddresses = new HashSet<PersonAddress>();
            PersonBatches = new HashSet<PersonBatch>();
            PersonContacts = new HashSet<PersonContact>();
            PersonDepartments = new HashSet<PersonDepartment>();
            PersonDisabilities = new HashSet<PersonDisability>();
            PersonEducations = new HashSet<PersonEducation>();
            PersonFamilyDetails = new HashSet<PersonFamilyDetail>();
            PersonHealthDetails = new HashSet<PersonHealthDetail>();
            PersonHobbyFavorites = new HashSet<PersonHobbyFavorite>();
            PersonLanguages = new HashSet<PersonLanguage>();
            PersonPrivateInformations = new HashSet<PersonPrivateInformation>();
            PersonPrograms = new HashSet<PersonProgram>();
            PersonSocialMediaAccounts = new HashSet<PersonSocialMediaAccount>();
            PersonSubPrograms = new HashSet<PersonSubProgram>();
            PersonWorkExperiences = new HashSet<PersonWorkExperience>();
            Tickets = new HashSet<Ticket>();
            #endregion
        }

        #region Generated Properties

        public string LoginId { get; set; }

        public int PersonTypeId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthLocation { get; set; }

        public char Gender { get; set; }

        public string LongText { get; set; }

        public string HighLightText { get; set; }

        public string Keywords { get; set; }

        public bool IsWorker { get; set; }

        public int WorkFrequencyId { get; set; }

        public DateTime JoiningDate { get; set; }

        public int? JoinedAsId { get; set; }

        public int? CountryId { get; set; }

        public string ProfilePicturePath { get; set; }

        public string HeroPicturePath { get; set; }


        #endregion

        #region Generated Relationships
        public virtual Country Country { get; set; }

        public virtual ICollection<CourseHead> CourseHeads { get; set; }

        public virtual ICollection<EventAttendance> EventAttendances { get; set; }

        public virtual ICollection<Course> HeadCourses { get; set; }

        public virtual ICollection<PersonAchievement> PersonAchievements { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        public virtual ICollection<PersonBatch> PersonBatches { get; set; }

        public virtual ICollection<PersonContact> PersonContacts { get; set; }

        public virtual ICollection<PersonDepartment> PersonDepartments { get; set; }

        public virtual ICollection<PersonDisability> PersonDisabilities { get; set; }

        public virtual ICollection<PersonEducation> PersonEducations { get; set; }

        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetails { get; set; }

        public virtual ICollection<PersonHealthDetail> PersonHealthDetails { get; set; }

        public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }

        public virtual ICollection<PersonLanguage> PersonLanguages { get; set; }

        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformations { get; set; }

        public virtual ICollection<PersonProgram> PersonPrograms { get; set; }

        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccounts { get; set; }

        public virtual ICollection<PersonSubProgram> PersonSubPrograms { get; set; }

        public virtual ICollection<PersonWorkExperience> PersonWorkExperiences { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual Detail TypeDetail { get; set; }

        public virtual Detail WorkFrequencyDetail { get; set; }

        #endregion

    }
}
