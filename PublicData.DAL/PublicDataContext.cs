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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=PublicData_19072020;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__City__StateId__534D60F1");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartedAt).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DepartmentHead>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentHead)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Depar__628FA481");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DepartmentHead)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Perso__619B8048");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.ExtraField)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Header)
                    .WithMany(p => p.Detail)
                    .HasForeignKey(d => d.HeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detail__HeaderId__59FA5E80");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__District__StateI__6FE99F9F");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Division)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Division__Depart__656C112C");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DivisionHead>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.DivisionHead)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DivisionH__Divis__693CA210");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DivisionHead)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DivisionH__Perso__68487DD7");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.Keywords)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId).HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Person__CountryI__5EBF139D");

                entity.HasOne(d => d.PersonType)
                    .WithMany(p => p.PersonPersonType)
                    .HasForeignKey(d => d.PersonTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__PersonTy__5CD6CB2B");

                entity.HasOne(d => d.WorkFrequency)
                    .WithMany(p => p.PersonWorkFrequency)
                    .HasForeignKey(d => d.WorkFrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__WorkFreq__5DCAEF64");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonAchievement>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Format)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GivenBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.AwardLevel)
                    .WithMany(p => p.PersonAchievement)
                    .HasForeignKey(d => d.AwardLevelId)
                    .HasConstraintName("FK__PersonAch__Award__6D0D32F4");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAchievement)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonAch__Perso__6C190EBB");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonAddress>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Line1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Line2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OtherCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherTaluka)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoadName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.Village)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__PersonAdd__CityI__787EE5A0");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__PersonAdd__Count__76969D2E");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__PersonAdd__Distr__7A672E12");

                entity.HasOne(d => d.HomeStatus)
                    .WithMany(p => p.PersonAddressHomeStatus)
                    .HasForeignKey(d => d.HomeStatusId)
                    .HasConstraintName("FK__PersonAdd__HomeS__7B5B524B");

                entity.HasOne(d => d.LocalityClass)
                    .WithMany(p => p.PersonAddressLocalityClass)
                    .HasForeignKey(d => d.LocalityClassId)
                    .HasConstraintName("FK__PersonAdd__Local__7C4F7684");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonAdd__Perso__75A278F5");

                entity.HasOne(d => d.ResidentialArea)
                    .WithMany(p => p.PersonAddressResidentialArea)
                    .HasForeignKey(d => d.ResidentialAreaId)
                    .HasConstraintName("FK__PersonAdd__Resid__7E37BEF6");

                entity.HasOne(d => d.ResidentialStatus)
                    .WithMany(p => p.PersonAddressResidentialStatus)
                    .HasForeignKey(d => d.ResidentialStatusId)
                    .HasConstraintName("FK__PersonAdd__Resid__7D439ABD");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__PersonAdd__State__778AC167");

                entity.HasOne(d => d.Taluka)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.TalukaId)
                    .HasConstraintName("FK__PersonAdd__Taluk__797309D9");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Detail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.PersonContact)
                    .HasForeignKey(d => d.ContactTypeId)
                    .HasConstraintName("FK__PersonCon__Conta__02084FDA");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonContact)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonCon__Perso__01142BA1");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonDisability>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Detail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonDisability)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonDis__Perso__04E4BC85");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonEducation>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.OtherCourse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDegree)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherMedium)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherSchool)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherUniversityBoard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonEducationCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PersonEdu__Cours__114A936A");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.PersonEducationDegree)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK__PersonEdu__Degre__10566F31");

                entity.HasOne(d => d.FromStd)
                    .WithMany(p => p.PersonEducationFromStd)
                    .HasForeignKey(d => d.FromStdId)
                    .HasConstraintName("FK__PersonEdu__FromS__0C85DE4D");

                entity.HasOne(d => d.Medium)
                    .WithMany(p => p.PersonEducationMedium)
                    .HasForeignKey(d => d.MediumId)
                    .HasConstraintName("FK__PersonEdu__Mediu__0E6E26BF");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonEducation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonEdu__Perso__0A9D95DB");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.PersonEducation)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__PersonEdu__Schoo__0B91BA14");

                entity.HasOne(d => d.ToStd)
                    .WithMany(p => p.PersonEducationToStd)
                    .HasForeignKey(d => d.ToStdId)
                    .HasConstraintName("FK__PersonEdu__ToStd__0D7A0286");

                entity.HasOne(d => d.UniversityBoard)
                    .WithMany(p => p.PersonEducationUniversityBoard)
                    .HasForeignKey(d => d.UniversityBoardId)
                    .HasConstraintName("FK__PersonEdu__Unive__0F624AF8");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonFamilyDetail>(entity =>
            {
                entity.Property(e => e.AnyDisability)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OtherCourse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherRelation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonFamilyDetailCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PersonFam__Cours__160F4887");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonFamilyDetail)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonFam__Perso__14270015");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.PersonFamilyDetailRelation)
                    .HasForeignKey(d => d.RelationId)
                    .HasConstraintName("FK__PersonFam__Relat__151B244E");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonHealthDetail>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Iq).HasColumnName("IQ");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHealthDetail)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHea__Perso__18EBB532");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonHobbyFavorite>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.HobbyFavorite)
                    .WithMany(p => p.PersonHobbyFavorite)
                    .HasForeignKey(d => d.HobbyFavoriteId)
                    .HasConstraintName("FK__PersonHob__Hobby__1CBC4616");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHobbyFavorite)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHob__Perso__1BC821DD");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonLanguage>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.OtherLanguage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PersonLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonLan__Langu__208CD6FA");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonLanguage)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonLan__Perso__1F98B2C1");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonPrivateInformation>(entity =>
            {
                entity.Property(e => e.AadharCardNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.OtherCaste)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherParentalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherReligion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.PersonPrivateInformationCaste)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK__PersonPri__Caste__25518C17");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PersonPrivateInformationCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__PersonPri__Categ__2645B050");

                entity.HasOne(d => d.ParentalStatus)
                    .WithMany(p => p.PersonPrivateInformationParentalStatus)
                    .HasForeignKey(d => d.ParentalStatusId)
                    .HasConstraintName("FK__PersonPri__Paren__2739D489");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPrivateInformation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonPri__Perso__236943A5");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.PersonPrivateInformationReligion)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK__PersonPri__Relig__245D67DE");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonSocialMediaAccount>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Link)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherAccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.PersonSocialMediaAccountAccountType)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__Accou__2B0A656D");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonSocialMediaAccount)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__Perso__2A164134");

                entity.HasOne(d => d.TypeOfUser)
                    .WithMany(p => p.PersonSocialMediaAccountTypeOfUser)
                    .HasForeignKey(d => d.TypeOfUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__TypeO__2BFE89A6");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonWorkExperience>(entity =>
            {
                entity.Property(e => e.ActualWork)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.OtherIndustry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherWorkType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.PersonWorkExperienceIndustry)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonWor__Indus__2FCF1A8A");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonWorkExperience)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonWor__Perso__2EDAF651");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PersonWorkExperienceStatus)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__PersonWor__Statu__31B762FC");

                entity.HasOne(d => d.WorkType)
                    .WithMany(p => p.PersonWorkExperienceWorkType)
                    .HasForeignKey(d => d.WorkTypeId)
                    .HasConstraintName("FK__PersonWor__WorkT__30C33EC3");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProgramAttendance>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ProgramAttendance)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProgramAt__Perso__367C1819");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramAttendance)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProgramAt__Progr__37703C52");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPersonContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPersonName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SchoolType)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.SchoolTypeId)
                    .HasConstraintName("FK__School__SchoolTy__07C12930");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__State__CountryId__5070F446");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Taluka>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LongText).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Taluka)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__Taluka__District__72C60C4A");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.TicketCount).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__PersonId__3B40CD36");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__ProgramI__3A4CA8FD");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.University)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Universit__CityI__3F115E1A");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

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
