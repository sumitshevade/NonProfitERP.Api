using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Detail : Entity
    {
        public Detail()
        {
            PersonAchievement = new HashSet<PersonAchievement>();
            PersonAddressHomeStatus = new HashSet<PersonAddress>();
            PersonAddressLocalityClass = new HashSet<PersonAddress>();
            PersonAddressResidentialArea = new HashSet<PersonAddress>();
            PersonAddressResidentialStatus = new HashSet<PersonAddress>();
            PersonContact = new HashSet<PersonContact>();
            PersonEducationCourse = new HashSet<PersonEducation>();
            PersonEducationDegree = new HashSet<PersonEducation>();
            PersonEducationFromStd = new HashSet<PersonEducation>();
            PersonEducationMedium = new HashSet<PersonEducation>();
            PersonEducationToStd = new HashSet<PersonEducation>();
            PersonEducationUniversityBoard = new HashSet<PersonEducation>();
            PersonFamilyDetailCourse = new HashSet<PersonFamilyDetail>();
            PersonFamilyDetailRelation = new HashSet<PersonFamilyDetail>();
            PersonHobbyFavorite = new HashSet<PersonHobbyFavorite>();
            PersonLanguage = new HashSet<PersonLanguage>();
            PersonPersonType = new HashSet<Person>();
            PersonPrivateInformationCaste = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationCategory = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationParentalStatus = new HashSet<PersonPrivateInformation>();
            PersonPrivateInformationReligion = new HashSet<PersonPrivateInformation>();
            PersonSocialMediaAccountAccountType = new HashSet<PersonSocialMediaAccount>();
            PersonSocialMediaAccountTypeOfUser = new HashSet<PersonSocialMediaAccount>();
            PersonWorkExperienceIndustry = new HashSet<PersonWorkExperience>();
            PersonWorkExperienceStatus = new HashSet<PersonWorkExperience>();
            PersonWorkExperienceWorkType = new HashSet<PersonWorkExperience>();
            PersonWorkFrequency = new HashSet<Person>();
            School = new HashSet<School>();
        }

        public int HeaderId { get; set; }
        public string Value { get; set; }
        public string ExtraField { get; set; }

        public virtual Header Header { get; set; }
        public virtual ICollection<PersonAchievement> PersonAchievement { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressHomeStatus { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressLocalityClass { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressResidentialArea { get; set; }
        public virtual ICollection<PersonAddress> PersonAddressResidentialStatus { get; set; }
        public virtual ICollection<PersonContact> PersonContact { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationCourse { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationDegree { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationFromStd { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationMedium { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationToStd { get; set; }
        public virtual ICollection<PersonEducation> PersonEducationUniversityBoard { get; set; }
        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetailCourse { get; set; }
        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetailRelation { get; set; }
        public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorite { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguage { get; set; }
        public virtual ICollection<Person> PersonPersonType { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationCaste { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationCategory { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationParentalStatus { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformationReligion { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccountAccountType { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccountTypeOfUser { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceIndustry { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceStatus { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperienceWorkType { get; set; }
        public virtual ICollection<Person> PersonWorkFrequency { get; set; }
        public virtual ICollection<School> School { get; set; }
    }
}
