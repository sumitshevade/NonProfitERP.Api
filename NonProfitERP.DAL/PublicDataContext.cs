using Microsoft.EntityFrameworkCore;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Mapping;
using NonProfitERP.Data.Mapping;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.DAL
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
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CourseHead> CourseHeads { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<EventAttendance> EventAttendances { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonAchievement> PersonAchievements { get; set; }
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }
        public virtual DbSet<PersonBatch> PersonBatches { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }
        public virtual DbSet<PersonDepartment> PersonDepartments { get; set; }
        public virtual DbSet<PersonDisability> PersonDisabilities { get; set; }
        public virtual DbSet<PersonEducation> PersonEducations { get; set; }
        public virtual DbSet<PersonFamilyDetail> PersonFamilyDetails { get; set; }
        public virtual DbSet<PersonHealthDetail> PersonHealthDetails { get; set; }
        public virtual DbSet<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguages { get; set; }
        public virtual DbSet<PersonProgram> PersonPrograms { get; set; }
        public virtual DbSet<PersonSubProgram> PersonSubPrograms { get; set; }
        public virtual DbSet<PersonPrivateInformation> PersonPrivateInformation { get; set; }
        public virtual DbSet<PersonSocialMediaAccount> PersonSocialMediaAccount { get; set; }
        public virtual DbSet<PersonWorkExperience> PersonWorkExperiencees { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<SubProgram> SubPrograms { get; set; }
        public virtual DbSet<Taluka> Talukas { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; }
        public virtual DbSet<TransactionLogValue> TransactionLogValues { get; set; }
        public virtual DbSet<University> Universities { get; set; }

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

                        item.CurrentValues[nameof(Entity.UpdatedById)] = user;
                        item.CurrentValues[nameof(Entity.UpdatedAt)] = DateTime.Now;
                        item.CurrentValues[nameof(Entity.IsActive)] = true;
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
