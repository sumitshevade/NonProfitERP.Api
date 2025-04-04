using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public class Root
    {
        public virtual IList<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual IList<AspNetRoles> AspNetRoles { get; set; }
        public virtual IList<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual IList<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual IList<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual IList<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual IList<AspNetUsers> AspNetUsers { get; set; }
        public virtual IList<Batch> Batches { get; set; }
        public virtual IList<City> Cities { get; set; }
        public virtual IList<Country> Countries { get; set; }
        public virtual IList<CourseHead> CourseHeads { get; set; }
        public virtual IList<Course> Courses { get; set; }
        public virtual IList<Department> Departments { get; set; }
        
        // Entire details
        public virtual IList<Detail> Details { get; set; }

        // Details has many tables inside, segregating those into diff classes
        public virtual IList<Detail> SchoolType { get; set; }
        public virtual IList<Detail> Syllabus { get; set; }

        public virtual IList<DeviceCodes> DeviceCodes { get; set; }
        public virtual IList<District> Districts { get; set; }
        public virtual IList<EventAttendance> EventAttendances { get; set; }
        public virtual IList<Event> Events { get; set; }
        public virtual IList<Header> Headers { get; set; }
        public virtual IList<Organization> Organizations { get; set; }
        public virtual IList<PersistedGrants> PersistedGrants { get; set; }
        public virtual IList<Person> People { get; set; }
        public virtual IList<PersonAchievement> PersonAchievements { get; set; }
        public virtual IList<PersonAddress> PersonAddresses { get; set; }
        public virtual IList<PersonBatch> PersonBatches { get; set; }
        public virtual IList<PersonContact> PersonContacts { get; set; }
        public virtual IList<PersonDepartment> PersonDepartments { get; set; }
        public virtual IList<PersonDisability> PersonDisabilities { get; set; }
        public virtual IList<PersonEducation> PersonEducations { get; set; }
        public virtual IList<PersonFamilyDetail> PersonFamilyDetails { get; set; }
        public virtual IList<PersonHealthDetail> PersonHealthDetails { get; set; }
        public virtual IList<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }
        public virtual IList<PersonLanguage> PersonLanguages { get; set; }
        public virtual IList<PersonProgram> PersonPrograms { get; set; }
        public virtual IList<PersonSubProgram> PersonSubPrograms { get; set; }
        public virtual IList<PersonPrivateInformation> PersonPrivateInformation { get; set; }
        public virtual IList<PersonSocialMediaAccount> PersonSocialMediaAccount { get; set; }
        public virtual IList<PersonWorkExperience> PersonWorkExperiencees { get; set; }
        public virtual IList<Program> Programs { get; set; }
        public virtual IList<School> Schools { get; set; }
        public virtual IList<State> States { get; set; }
        public virtual IList<SubProgram> SubPrograms { get; set; }
        public virtual IList<Taluka> Talukas { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        public virtual IList<TransactionLog> TransactionLogs { get; set; }
        public virtual IList<TransactionLogValue> TransactionLogValues { get; set; }
        public virtual IList<University> Universities { get; set; }
    }
}
