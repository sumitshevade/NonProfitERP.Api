using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Entities;
using PublicData.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Data.Mapping;
using PublicData.DAL.Mapping;

namespace PublicData.DAL
{
    public partial class PublicDataContext : DbContext
    {
        public PublicDataContext()
        {
        }

        private readonly ICurrentUserService _currentUserService;

        public PublicDataContext(DbContextOptions<PublicDataContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region -- Mappings

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CourseHead> CourseHead { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<DivisionHead> DivisionHead { get; set; }
        public virtual DbSet<EventAttendance> EventAttendance { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Header> Header { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAchievement> PersonAchievement { get; set; }
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonBatch> PersonBatch { get; set; }
        public virtual DbSet<PersonContact> PersonContact { get; set; }
        public virtual DbSet<PersonDepartment> PersonDepartment { get; set; }
        public virtual DbSet<PersonDisability> PersonDisability { get; set; }
        public virtual DbSet<PersonEducation> PersonEducation { get; set; }
        public virtual DbSet<PersonFamilyDetail> PersonFamilyDetail { get; set; }
        public virtual DbSet<PersonHealthDetail> PersonHealthDetail { get; set; }
        public virtual DbSet<PersonHobbyFavorite> PersonHobbyFavorite { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        public virtual DbSet<PersonProgram> PersonProgram { get; set; }
        public virtual DbSet<PersonSubProgram> PersonSubProgram { get; set; }
        public virtual DbSet<PersonPrivateInformation> PersonPrivateInformation { get; set; }
        public virtual DbSet<PersonSocialMediaAccount> PersonSocialMediaAccount { get; set; }
        public virtual DbSet<PersonWorkExperience> PersonWorkExperience { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SubProgram> SubProgram { get; set; }
        public virtual DbSet<Taluka> Taluka { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TransactionLog> TransactionLog { get; set; }
        public virtual DbSet<TransactionLogValue> TransactionLogValue { get; set; }
        public virtual DbSet<University> University { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration

            modelBuilder.ApplyConfiguration(new AspNetRoleClaimsMap());
            modelBuilder.ApplyConfiguration(new AspNetRolesMap());
            modelBuilder.ApplyConfiguration(new AspNetUserClaimsMap());
            modelBuilder.ApplyConfiguration(new AspNetUserLoginsMap());
            modelBuilder.ApplyConfiguration(new AspNetUserRolesMap());
            modelBuilder.ApplyConfiguration(new AspNetUsersMap());
            modelBuilder.ApplyConfiguration(new AspNetUserTokensMap());
            modelBuilder.ApplyConfiguration(new BatchMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new CourseHeadMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new DetailMap());
            modelBuilder.ApplyConfiguration(new DeviceCodesMap());
            modelBuilder.ApplyConfiguration(new DistrictMap());
            modelBuilder.ApplyConfiguration(new DivisionHeadMap());
            modelBuilder.ApplyConfiguration(new DivisionMap());
            modelBuilder.ApplyConfiguration(new EventAttendanceMap());
            modelBuilder.ApplyConfiguration(new EventMap());
            modelBuilder.ApplyConfiguration(new HeaderMap());
            modelBuilder.ApplyConfiguration(new OrganizationMap());
            modelBuilder.ApplyConfiguration(new PersistedGrantsMap());
            modelBuilder.ApplyConfiguration(new PersonAchievementMap());
            modelBuilder.ApplyConfiguration(new PersonAddressMap());
            modelBuilder.ApplyConfiguration(new PersonBatchMap());
            modelBuilder.ApplyConfiguration(new PersonContactMap());
            modelBuilder.ApplyConfiguration(new PersonDepartmentMap());
            modelBuilder.ApplyConfiguration(new PersonDisabilityMap());
            modelBuilder.ApplyConfiguration(new PersonEducationMap());
            modelBuilder.ApplyConfiguration(new PersonFamilyDetailMap());
            modelBuilder.ApplyConfiguration(new PersonHealthDetailMap());
            modelBuilder.ApplyConfiguration(new PersonHobbyFavoriteMap());
            modelBuilder.ApplyConfiguration(new PersonLanguageMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new PersonPrivateInformationMap());
            modelBuilder.ApplyConfiguration(new PersonProgramMap());
            modelBuilder.ApplyConfiguration(new PersonSocialMediaAccountMap());
            modelBuilder.ApplyConfiguration(new PersonSubProgramMap());
            modelBuilder.ApplyConfiguration(new PersonWorkExperienceMap());
            modelBuilder.ApplyConfiguration(new ProgramMap());
            modelBuilder.ApplyConfiguration(new SchoolMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new SubProgramMap());
            modelBuilder.ApplyConfiguration(new TalukaMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new TransactionLogMap());
            modelBuilder.ApplyConfiguration(new TransactionLogValueMap());
            modelBuilder.ApplyConfiguration(new UniversityMap());

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            var modified = ChangeTracker.Entries().Where(
                x => x.State == EntityState.Added ||
                x.State == EntityState.Modified
                );
            var user = _currentUserService.UserId;

            foreach (var item in modified)
            {
                if (item.Entity is Entity entity)
                {
                    if (item.State == EntityState.Added)
                    {
                        item.CurrentValues[nameof(Entity.CreatedById)] = user;
                        item.CurrentValues[nameof(Entity.CreatedAt)] = DateTime.Now;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        // Ignore properties
                        item.Property("CreatedAt").IsModified = false;
                        item.Property("CreatedById").IsModified = false;

                        item.CurrentValues[nameof(Entity.UpdatedById)] = user;
                        item.CurrentValues[nameof(Entity.UpdatedAt)] = DateTime.Now;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
