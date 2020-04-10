using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    /// <summary>
    /// Header-Detail class.
    /// </summary>
    public class Detail : BaseClass
    {
        public Detail()
        {
            PeopleJoinedAs = new HashSet<People>();
            PeoplePersonTypes = new HashSet<People>();
            PeopleWorkFrequency = new HashSet<People>();
            PersonAddressHomeStatus = new HashSet<PersonAddress>();
            PersonAddressLocalityClass = new HashSet<PersonAddress>();
            PersonAddressResidentialStatus = new HashSet<PersonAddress>();
            PersonContacts = new HashSet<PersonContact>();
            PersonEducationCourses = new HashSet<PersonEducation>();
            PersonEducationDegrees = new HashSet<PersonEducation>();
            PersonEducationFromStds = new HashSet<PersonEducation>();
            PersonEducationSchools = new HashSet<PersonEducation>();
            PersonEducationToStds = new HashSet<PersonEducation>();
            PersonEducationUniversityBoards = new HashSet<PersonEducation>();
            PersonFamilyDetailCourses = new HashSet<PersonFamilyDetail>();
            PersonFamilyDetailRelations = new HashSet<PersonFamilyDetail>();
            PersonHobbyFavorites = new HashSet<PersonHobbyFavorite>();
            PersonLanguages = new HashSet<PersonLanguage>();
            PersonPrivateInformationCastes = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationParentalStatus = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationReligions = new HashSet<PersonPrivateInformation>();
            PersonSocialMediaAccountAccountTypes = new HashSet<PersonSocialMediaAccount>();
            PersonSocialMediaAccountTypeOfUsers = new HashSet<PersonSocialMediaAccount>();
            PersonWorkExperienceIndustries = new HashSet<PersonWorkExperience>();
            PersonWorkExperienceWorkTypes = new HashSet<PersonWorkExperience>();
        }

        /// <summary>
        /// Header reference for detail.
        /// </summary>
        [Required, Display(Name = "Header")]
        public int HeaderId { get; set; }

        /// <summary>
        /// Detail value.
        /// </summary>
        [Required, StringLength(50)]
        public string Value { get; set; }

        /// <summary>
        /// Extra text to mention if anything related to value.
        /// </summary>
        [StringLength(250), Display(Name = "Description")]
        public string ExtraField { get; set; }

        #region --- Relationships ---
        public virtual Header Header { get; set; }
        public virtual ICollection<People> PeopleJoinedAs { get; set; }
        public virtual ICollection<People> PeoplePersonTypes { get; set; }
        public virtual ICollection<People> PeopleWorkFrequency { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressHomeStatus { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressLocalityClass { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressResidentialStatus { get; set; }
        public virtual ICollection<PersonContact> PersonContacts { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationCourses { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationDegrees { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationFromStds { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationSchools { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationToStds { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationUniversityBoards { get; set; }
        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetailCourses { get; set; }
        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetailRelations { get; set; }
        public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguages { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationCastes { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationParentalStatus { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationReligions { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccountAccountTypes { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccountTypeOfUsers { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceIndustries { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceWorkTypes { get; set; }

        #endregion
    }
}
