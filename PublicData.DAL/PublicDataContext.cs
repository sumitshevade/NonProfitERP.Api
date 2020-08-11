using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Entities;
using PublicData.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentHead> DepartmentHead { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<DivisionHead> DivisionHead { get; set; }
        public virtual DbSet<Header> Header { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAchievement> PersonAchievement { get; set; }
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonContact> PersonContact { get; set; }
        public virtual DbSet<PersonDisability> PersonDisability { get; set; }
        public virtual DbSet<PersonEducation> PersonEducation { get; set; }
        public virtual DbSet<PersonFamilyDetail> PersonFamilyDetail { get; set; }
        public virtual DbSet<PersonHealthDetail> PersonHealthDetail { get; set; }
        public virtual DbSet<PersonHobbyFavorite> PersonHobbyFavorite { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        public virtual DbSet<PersonPrivateInformation> PersonPrivateInformation { get; set; }
        public virtual DbSet<PersonSocialMediaAccount> PersonSocialMediaAccount { get; set; }
        public virtual DbSet<PersonWorkExperience> PersonWorkExperience { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<ProgramAttendance> ProgramAttendance { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Taluka> Taluka { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<University> University { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseLazyLoadingProxies()
        //            .UseSqlServer("Server=.;Database=PublicData_19072020;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new Mapping.AspNetRoleClaimsMap());
            modelBuilder.ApplyConfiguration(new Mapping.AspNetRolesMap());
            modelBuilder.ApplyConfiguration(new Mapping.AspNetUserClaimsMap());
            modelBuilder.ApplyConfiguration(new Mapping.AspNetUserLoginsMap());
            modelBuilder.ApplyConfiguration(new Mapping.AspNetUserRolesMap());
            modelBuilder.ApplyConfiguration(new Mapping.AspNetUsersMap());
            modelBuilder.ApplyConfiguration(new Mapping.AspNetUserTokensMap());
            modelBuilder.ApplyConfiguration(new Mapping.CityMap());
            modelBuilder.ApplyConfiguration(new Mapping.CountryMap());
            modelBuilder.ApplyConfiguration(new Mapping.DepartmentHeadMap());
            modelBuilder.ApplyConfiguration(new Mapping.DepartmentMap());
            modelBuilder.ApplyConfiguration(new Mapping.DetailMap());
            modelBuilder.ApplyConfiguration(new Mapping.DeviceCodesMap());
            modelBuilder.ApplyConfiguration(new Mapping.DistrictMap());
            modelBuilder.ApplyConfiguration(new Mapping.DivisionHeadMap());
            modelBuilder.ApplyConfiguration(new Mapping.DivisionMap());
            modelBuilder.ApplyConfiguration(new Mapping.HeaderMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersistedGrantsMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonAchievementMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonAddressMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonContactMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonDisabilityMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonEducationMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonFamilyDetailMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonHealthDetailMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonHobbyFavoriteMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonLanguageMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonPrivateInformationMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonSocialMediaAccountMap());
            modelBuilder.ApplyConfiguration(new Mapping.PersonWorkExperienceMap());
            modelBuilder.ApplyConfiguration(new Mapping.ProgramAttendanceMap());
            modelBuilder.ApplyConfiguration(new Mapping.ProgramMap());
            modelBuilder.ApplyConfiguration(new Mapping.SchoolMap());
            modelBuilder.ApplyConfiguration(new Mapping.StateMap());
            modelBuilder.ApplyConfiguration(new Mapping.TalukaMap());
            modelBuilder.ApplyConfiguration(new Mapping.TicketMap());
            modelBuilder.ApplyConfiguration(new Mapping.TransactionLogMap());
            modelBuilder.ApplyConfiguration(new Mapping.TransactionLogValueMap());
            modelBuilder.ApplyConfiguration(new Mapping.UniversityMap());
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
