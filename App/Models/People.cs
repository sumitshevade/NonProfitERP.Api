using System;
using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// Base class of the person.
    /// </summary>
    public class People : BaseClass
    {
        public People()
        {
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
        }

        /// <summary>
        /// How this person engage with organization?
        /// </summary>
        public int PersonTypeId { get; set; }

        /// <summary>
        /// Organization reference for person.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Person firstname.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person middlename.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Person lastname.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Person birthdate.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Person birth location.
        /// </summary>
        public string BirthLocation { get; set; }

        /// <summary>
        /// Person description.
        /// </summary>
        public string LongText { get; set; }

        /// <summary>
        /// Person keywords on which we can search.
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Is this person working for our organization?
        /// </summary>
        public bool IsWorker { get; set; }

        /// <summary>
        /// Work frequency of the person. e.g. Daily, Weekly, Monthly, Yearly, for programs only, etc.
        /// </summary>
        public int WorkFrequency { get; set; }

        /// <summary>
        /// Person joining date.
        /// </summary>
        public DateTime? JoiningDate { get; set; }

        /// <summary>
        /// Person joined as. e.g. Teacher, etc.
        /// </summary>
        public int? JoinedAsId { get; set; }

        /// <summary>
        /// Person nationality.
        /// </summary>
        public int? CountryId { get; set; }

        #region --- Relationships ---
        public virtual Country Country { get; set; }
        public virtual Detail JoinedAs { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Detail PersonType { get; set; }
        public virtual Detail WorkFrequencyNavigation { get; set; }
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

        #endregion
    }
}
