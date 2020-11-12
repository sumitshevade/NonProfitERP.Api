using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Detail : Entity
    {
        public Detail()
        {
            #region Generated Constructor
            AccountTypePersonSocialMediaAccounts = new HashSet<PersonSocialMediaAccount>();
            AwardLevelPersonAchievements = new HashSet<PersonAchievement>();
            CastePersonPrivateInformations = new HashSet<PersonPrivateInformation>();
            CategoryPersonPrivateInformations = new HashSet<PersonPrivateInformation>();
            ContactTypePersonContacts = new HashSet<PersonContact>();
            CoursePersonEducations = new HashSet<PersonEducation>();
            CoursePersonFamilyDetails = new HashSet<PersonFamilyDetail>();
            DegreePersonEducations = new HashSet<PersonEducation>();
            DepartmentPersonWorkExperiences = new HashSet<PersonWorkExperience>();
            DesignationPersonWorkExperiences = new HashSet<PersonWorkExperience>();
            FromStdPersonEducations = new HashSet<PersonEducation>();
            HobbyFavoritePersonHobbyFavorites = new HashSet<PersonHobbyFavorite>();
            HomeStatusPersonAddresses = new HashSet<PersonAddress>();
            LanguagePersonLanguages = new HashSet<PersonLanguage>();
            LocalityClassPersonAddresses = new HashSet<PersonAddress>();
            MediumPersonEducations = new HashSet<PersonEducation>();
            ParentalStatusPersonPrivateInformations = new HashSet<PersonPrivateInformation>();
            RelationPersonFamilyDetails = new HashSet<PersonFamilyDetail>();
            ReligionPersonPrivateInformations = new HashSet<PersonPrivateInformation>();
            ResidentialAreaPersonAddresses = new HashSet<PersonAddress>();
            ResidentialStatusPersonAddresses = new HashSet<PersonAddress>();
            ToStdPersonEducations = new HashSet<PersonEducation>();
            TypeOfUserPersonSocialMediaAccounts = new HashSet<PersonSocialMediaAccount>();
            TypePeople = new HashSet<Person>();
            TypeSchools = new HashSet<School>();
            UniversityBoardPersonEducations = new HashSet<PersonEducation>();
            WorkFrequencyPeople = new HashSet<Person>();
            WorkTypePersonWorkExperiences = new HashSet<PersonWorkExperience>();
            #endregion
        }

        #region Generated Properties
        
        public int HeaderId { get; set; }

        public string Value { get; set; }

        public string ExtraField { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PersonSocialMediaAccount> AccountTypePersonSocialMediaAccounts { get; set; }

        public virtual ICollection<PersonAchievement> AwardLevelPersonAchievements { get; set; }

        public virtual ICollection<PersonPrivateInformation> CastePersonPrivateInformations { get; set; }

        public virtual ICollection<PersonPrivateInformation> CategoryPersonPrivateInformations { get; set; }

        public virtual ICollection<PersonContact> ContactTypePersonContacts { get; set; }

        public virtual ICollection<PersonEducation> CoursePersonEducations { get; set; }

        public virtual ICollection<PersonFamilyDetail> CoursePersonFamilyDetails { get; set; }

        public virtual ICollection<PersonEducation> DegreePersonEducations { get; set; }

        public virtual ICollection<PersonWorkExperience> DepartmentPersonWorkExperiences { get; set; }

        public virtual ICollection<PersonWorkExperience> DesignationPersonWorkExperiences { get; set; }

        public virtual ICollection<PersonEducation> FromStdPersonEducations { get; set; }

        public virtual Header Header { get; set; }

        public virtual ICollection<PersonHobbyFavorite> HobbyFavoritePersonHobbyFavorites { get; set; }

        public virtual ICollection<PersonAddress> HomeStatusPersonAddresses { get; set; }

        public virtual ICollection<PersonLanguage> LanguagePersonLanguages { get; set; }

        public virtual ICollection<PersonAddress> LocalityClassPersonAddresses { get; set; }

        public virtual ICollection<PersonEducation> MediumPersonEducations { get; set; }

        public virtual ICollection<PersonPrivateInformation> ParentalStatusPersonPrivateInformations { get; set; }

        public virtual ICollection<PersonFamilyDetail> RelationPersonFamilyDetails { get; set; }

        public virtual ICollection<PersonPrivateInformation> ReligionPersonPrivateInformations { get; set; }

        public virtual ICollection<PersonAddress> ResidentialAreaPersonAddresses { get; set; }

        public virtual ICollection<PersonAddress> ResidentialStatusPersonAddresses { get; set; }

        public virtual ICollection<PersonEducation> ToStdPersonEducations { get; set; }

        public virtual ICollection<PersonSocialMediaAccount> TypeOfUserPersonSocialMediaAccounts { get; set; }

        public virtual ICollection<Person> TypePeople { get; set; }

        public virtual ICollection<School> TypeSchools { get; set; }

        public virtual ICollection<PersonEducation> UniversityBoardPersonEducations { get; set; }

        public virtual ICollection<Person> WorkFrequencyPeople { get; set; }

        public virtual ICollection<PersonWorkExperience> WorkTypePersonWorkExperiences { get; set; }

        #endregion

    }
}
