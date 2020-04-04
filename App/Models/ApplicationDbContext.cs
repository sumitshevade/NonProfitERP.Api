using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    //public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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
        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<DivisionHead> DivisionHead { get; set; }
        public virtual DbSet<Header> Header { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAchievement> PersonAchievement { get; set; }
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonContact> PersonContact { get; set; }
        public virtual DbSet<PersonDisability> PersonDisability { get; set; }
        public virtual DbSet<PersonEducation> PersonEducation { get; set; }
        public virtual DbSet<PersonFamilyDetails> PersonFamilyDetails { get; set; }
        public virtual DbSet<PersonHealthDetails> PersonHealthDetails { get; set; }
        public virtual DbSet<PersonHobbyFavorite> PersonHobbyFavorite { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        public virtual DbSet<PersonPrivateInformation> PersonPrivateInformation { get; set; }
        public virtual DbSet<PersonSocialMediaAccount> PersonSocialMediaAccount { get; set; }
        public virtual DbSet<PersonWorkExperience> PersonWorkExperience { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<ProgramAttendance> ProgramAttendance { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<University> University { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=PublicData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

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
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__City__StateId__2B5F6B28");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartedAt).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<DepartmentHead>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentHead)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Depar__3C89F72A");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DepartmentHead)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Perso__3B95D2F1");
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.ExtraField)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Header)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.HeaderId)
                    .HasConstraintName("FK__Details__HeaderI__320C68B7");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Division)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Division__Depart__4242D080");
            });

            modelBuilder.Entity<DivisionHead>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.DivisionHead)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DivisionH__Divis__46136164");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DivisionHead)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DivisionH__Perso__451F3D2B");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PanNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

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

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Person__CountryI__38B96646");

                entity.HasOne(d => d.JoinedAs)
                    .WithMany(p => p.PersonJoinedAs)
                    .HasForeignKey(d => d.JoinedAsId)
                    .HasConstraintName("FK__Person__JoinedAs__37C5420D");

                entity.HasOne(d => d.PersonType)
                    .WithMany(p => p.PersonPersonType)
                    .HasForeignKey(d => d.PersonTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__PersonTy__34E8D562");

                entity.HasOne(d => d.WorkFrequencyNavigation)
                    .WithMany(p => p.PersonWorkFrequencyNavigation)
                    .HasForeignKey(d => d.WorkFrequency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__WorkFreq__36D11DD4");
            });

            modelBuilder.Entity<PersonAchievement>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

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

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAchievement)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__PersonAch__Perso__5090EFD7");
            });

            modelBuilder.Entity<PersonAddress>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Line1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Line2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoadName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__PersonAdd__CityI__5649C92D");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__PersonAdd__Count__546180BB");

                entity.HasOne(d => d.HomeStatus)
                    .WithMany(p => p.PersonAddressHomeStatus)
                    .HasForeignKey(d => d.HomeStatusId)
                    .HasConstraintName("FK__PersonAdd__HomeS__5832119F");

                entity.HasOne(d => d.LocalityClassNavigation)
                    .WithMany(p => p.PersonAddressLocalityClassNavigation)
                    .HasForeignKey(d => d.LocalityClass)
                    .HasConstraintName("FK__PersonAdd__Local__592635D8");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonAdd__Perso__536D5C82");

                entity.HasOne(d => d.ResidentialStatusNavigation)
                    .WithMany(p => p.PersonAddressResidentialStatusNavigation)
                    .HasForeignKey(d => d.ResidentialStatus)
                    .HasConstraintName("FK__PersonAdd__Resid__5A1A5A11");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__PersonAdd__State__5555A4F4");
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Detail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.ContactTypeNavigation)
                    .WithMany(p => p.PersonContact)
                    .HasForeignKey(d => d.ContactType)
                    .HasConstraintName("FK__PersonCon__Conta__5DEAEAF5");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonContact)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonCon__Perso__5CF6C6BC");
            });

            modelBuilder.Entity<PersonDisability>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Detail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonDisability)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonDis__Perso__61BB7BD9");
            });

            modelBuilder.Entity<PersonEducation>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonEducationCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PersonEdu__Cours__6A50C1DA");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.PersonEducationDegree)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK__PersonEdu__Degre__695C9DA1");

                entity.HasOne(d => d.FromStd)
                    .WithMany(p => p.PersonEducationFromStd)
                    .HasForeignKey(d => d.FromStdId)
                    .HasConstraintName("FK__PersonEdu__FromS__668030F6");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonEducation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonEdu__Perso__6497E884");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.PersonEducationSchool)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__PersonEdu__Schoo__658C0CBD");

                entity.HasOne(d => d.ToStd)
                    .WithMany(p => p.PersonEducationToStd)
                    .HasForeignKey(d => d.ToStdId)
                    .HasConstraintName("FK__PersonEdu__ToStd__6774552F");

                entity.HasOne(d => d.UniversityBoard)
                    .WithMany(p => p.PersonEducationUniversityBoard)
                    .HasForeignKey(d => d.UniversityBoardId)
                    .HasConstraintName("FK__PersonEdu__Unive__68687968");
            });

            modelBuilder.Entity<PersonFamilyDetails>(entity =>
            {
                entity.Property(e => e.AnyDisability)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

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

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonFamilyDetailsCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PersonFam__Cours__6F1576F7");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonFamilyDetails)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__PersonFam__Perso__6D2D2E85");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.PersonFamilyDetailsRelation)
                    .HasForeignKey(d => d.RelationId)
                    .HasConstraintName("FK__PersonFam__Relat__6E2152BE");
            });

            modelBuilder.Entity<PersonHealthDetails>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Iq).HasColumnName("IQ");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHealthDetails)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHea__Perso__71F1E3A2");
            });

            modelBuilder.Entity<PersonHobbyFavorite>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.HobbyFavorite)
                    .WithMany(p => p.PersonHobbyFavorite)
                    .HasForeignKey(d => d.HobbyFavoriteId)
                    .HasConstraintName("FK__PersonHob__Hobby__75C27486");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHobbyFavorite)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHob__Perso__74CE504D");
            });

            modelBuilder.Entity<PersonLanguage>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PersonLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonLan__Langu__7993056A");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonLanguage)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonLan__Perso__789EE131");
            });

            modelBuilder.Entity<PersonPrivateInformation>(entity =>
            {
                entity.Property(e => e.AadharCardNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.PersonPrivateInformationCaste)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK__PersonPri__Caste__4CC05EF3");

                entity.HasOne(d => d.ParentalStatus)
                    .WithMany(p => p.PersonPrivateInformationParentalStatus)
                    .HasForeignKey(d => d.ParentalStatusId)
                    .HasConstraintName("FK__PersonPri__Paren__4DB4832C");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPrivateInformation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonPri__Perso__48EFCE0F");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.PersonPrivateInformationReligion)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK__PersonPri__Relig__4BCC3ABA");
            });

            modelBuilder.Entity<PersonSocialMediaAccount>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Link)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.PersonSocialMediaAccountAccountType)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__Accou__7E57BA87");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonSocialMediaAccount)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__Perso__7D63964E");

                entity.HasOne(d => d.TypeOfUser)
                    .WithMany(p => p.PersonSocialMediaAccountTypeOfUser)
                    .HasForeignKey(d => d.TypeOfUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__TypeO__7F4BDEC0");
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

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.PersonWorkExperienceIndustry)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonWor__Indus__031C6FA4");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonWorkExperience)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonWor__Perso__02284B6B");

                entity.HasOne(d => d.WorkType)
                    .WithMany(p => p.PersonWorkExperienceWorkType)
                    .HasForeignKey(d => d.WorkTypeId)
                    .HasConstraintName("FK__PersonWor__WorkT__041093DD");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProgramAttendance>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ProgramAttendance)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProgramAt__Perso__0E8E2250");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramAttendance)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProgramAt__Progr__0F824689");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__State__CountryId__2882FE7D");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__PersonId__0BB1B5A5");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.University)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Universit__CityI__06ED0088");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
