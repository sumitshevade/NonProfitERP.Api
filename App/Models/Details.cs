using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Details
    {
        public Details()
        {
            PersonAddressHomeStatus = new HashSet<PersonAddress>();
            PersonAddressLocalityClassNavigation = new HashSet<PersonAddress>();
            PersonAddressResidentialStatusNavigation = new HashSet<PersonAddress>();
            PersonContact = new HashSet<PersonContact>();
            PersonEducationCourse = new HashSet<PersonEducation>();
            PersonEducationDegree = new HashSet<PersonEducation>();
            PersonEducationFromStd = new HashSet<PersonEducation>();
            PersonEducationSchool = new HashSet<PersonEducation>();
            PersonEducationToStd = new HashSet<PersonEducation>();
            PersonEducationUniversityBoard = new HashSet<PersonEducation>();
            PersonFamilyDetailsCourse = new HashSet<PersonFamilyDetails>();
            PersonFamilyDetailsRelation = new HashSet<PersonFamilyDetails>();
            PersonHobbyFavorite = new HashSet<PersonHobbyFavorite>();
            PersonJoinedAs = new HashSet<Person>();
            PersonLanguage = new HashSet<PersonLanguage>();
            PersonPersonType = new HashSet<Person>();
            PersonPrivateInformationCaste = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationParentalStatus = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationReligion = new HashSet<PersonPrivateInformation>();
            PersonSocialMediaAccountAccountType = new HashSet<PersonSocialMediaAccount>();
            PersonSocialMediaAccountTypeOfUser = new HashSet<PersonSocialMediaAccount>();
            PersonWorkExperienceIndustry = new HashSet<PersonWorkExperience>();
            PersonWorkExperienceWorkType = new HashSet<PersonWorkExperience>();
            PersonWorkFrequencyNavigation = new HashSet<Person>();
        }

        public int Id { get; set; }
        public int? HeaderId { get; set; }
        public string Value { get; set; }
        public string ExtraField { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Header Header { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressHomeStatus { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressLocalityClassNavigation { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressResidentialStatusNavigation { get; set; }
        public virtual ICollection<PersonContact> PersonContact { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationCourse { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationDegree { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationFromStd { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationSchool { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationToStd { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationUniversityBoard { get; set; }
        public virtual ICollection<PersonFamilyDetails> PersonFamilyDetailsCourse { get; set; }
        public virtual ICollection<PersonFamilyDetails> PersonFamilyDetailsRelation { get; set; }
        public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorite { get; set; }
        public virtual ICollection<Person> PersonJoinedAs { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguage { get; set; }
        public virtual ICollection<Person> PersonPersonType { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationCaste { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationParentalStatus { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationReligion { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccountAccountType { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccountTypeOfUser { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceIndustry { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceWorkType { get; set; }
        public virtual ICollection<Person> PersonWorkFrequencyNavigation { get; set; }
    }
}
