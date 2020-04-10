using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    //public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentHead> DepartmentHeads { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<DivisionHead> DivisionHeads { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PersonAchievement> PersonAchievements { get; set; }
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }
        public virtual DbSet<PersonDisability> PersonDisabilities { get; set; }
        public virtual DbSet<PersonEducation> PersonEducations { get; set; }
        public virtual DbSet<PersonFamilyDetail> PersonFamilyDetails { get; set; }
        public virtual DbSet<PersonHealthDetail> PersonHealthDetails { get; set; }
        public virtual DbSet<PersonHobbyFavorite> PersonHobbyFavorites { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguages { get; set; }
        public virtual DbSet<PersonPrivateInformation> PersonPrivateInformations { get; set; }
        public virtual DbSet<PersonSocialMediaAccount> PersonSocialMediaAccounts { get; set; }
        public virtual DbSet<PersonWorkExperience> PersonWorkExperiences { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<ProgramAttendance> ProgramAttendances { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<University> Universities { get; set; }

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
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__Cities__StateId__2704CA5F");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartedAt).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Organ__2F9A1060");
            });

            modelBuilder.Entity<DepartmentHead>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentHeads)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Depar__3DE82FB7");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DepartmentHeads)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Perso__3CF40B7E");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.HeaderId)
                    .HasConstraintName("FK__Details__HeaderI__32767D0B");
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

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Divisions)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Divisions__Depar__40C49C62");
            });

            modelBuilder.Entity<DivisionHead>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.DivisionHeads)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DivisionH__Divis__44952D46");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DivisionHeads)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DivisionH__Perso__43A1090D");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Headers)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Headers__Organiz__2CBDA3B5");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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

                entity.Property(e => e.UpdatedById).HasMaxLength(450);
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__People__CountryI__3A179ED3");

                entity.HasOne(d => d.JoinedAs)
                    .WithMany(p => p.PeopleJoinedAs)
                    .HasForeignKey(d => d.JoinedAsId)
                    .HasConstraintName("FK__People__JoinedAs__39237A9A");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__People__Organiza__36470DEF");

                entity.HasOne(d => d.PersonType)
                    .WithMany(p => p.PeoplePersonTypes)
                    .HasForeignKey(d => d.PersonTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__People__PersonTy__3552E9B6");

                entity.HasOne(d => d.WorkFrequencyNavigation)
                    .WithMany(p => p.PeopleWorkFrequency)
                    .HasForeignKey(d => d.WorkFrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__People__WorkFreq__382F5661");
            });

            modelBuilder.Entity<PersonAchievement>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAchievements)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__PersonAch__Perso__4F12BBB9");
            });

            modelBuilder.Entity<PersonAddress>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PersonAddresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__PersonAdd__CityI__54CB950F");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PersonAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__PersonAdd__Count__52E34C9D");

                entity.HasOne(d => d.HomeStatus)
                    .WithMany(p => p.PersonAddressHomeStatus)
                    .HasForeignKey(d => d.HomeStatusId)
                    .HasConstraintName("FK__PersonAdd__HomeS__56B3DD81");

                entity.HasOne(d => d.LocalityClassNavigation)
                    .WithMany(p => p.PersonAddressLocalityClass)
                    .HasForeignKey(d => d.LocalityClassId)
                    .HasConstraintName("FK__PersonAdd__Local__57A801BA");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAddresses)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonAdd__Perso__51EF2864");

                entity.HasOne(d => d.ResidentialStatusNavigation)
                    .WithMany(p => p.PersonAddressResidentialStatus)
                    .HasForeignKey(d => d.ResidentialStatusId)
                    .HasConstraintName("FK__PersonAdd__Resid__589C25F3");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.PersonAddresses)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__PersonAdd__State__53D770D6");
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Detail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.ContactTypeNavigation)
                    .WithMany(p => p.PersonContacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .HasConstraintName("FK__PersonCon__Conta__5C6CB6D7");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonContacts)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonCon__Perso__5B78929E");
            });

            modelBuilder.Entity<PersonDisability>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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
                    .WithMany(p => p.PersonDisabilities)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonDis__Perso__603D47BB");
            });

            modelBuilder.Entity<PersonEducation>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonEducationCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PersonEdu__Cours__68D28DBC");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.PersonEducationDegrees)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK__PersonEdu__Degre__67DE6983");

                entity.HasOne(d => d.FromStd)
                    .WithMany(p => p.PersonEducationFromStds)
                    .HasForeignKey(d => d.FromStdId)
                    .HasConstraintName("FK__PersonEdu__FromS__6501FCD8");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonEducations)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonEdu__Perso__6319B466");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.PersonEducationSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__PersonEdu__Schoo__640DD89F");

                entity.HasOne(d => d.ToStd)
                    .WithMany(p => p.PersonEducationToStds)
                    .HasForeignKey(d => d.ToStdId)
                    .HasConstraintName("FK__PersonEdu__ToStd__65F62111");

                entity.HasOne(d => d.UniversityBoard)
                    .WithMany(p => p.PersonEducationUniversityBoards)
                    .HasForeignKey(d => d.UniversityBoardId)
                    .HasConstraintName("FK__PersonEdu__Unive__66EA454A");
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

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

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

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonFamilyDetailCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PersonFam__Cours__6D9742D9");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonFamilyDetails)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__PersonFam__Perso__6BAEFA67");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.PersonFamilyDetailRelations)
                    .HasForeignKey(d => d.RelationId)
                    .HasConstraintName("FK__PersonFam__Relat__6CA31EA0");
            });

            modelBuilder.Entity<PersonHealthDetail>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Iq).HasColumnName("IQ");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHealthDetails)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHea__Perso__7073AF84");
            });

            modelBuilder.Entity<PersonHobbyFavorite>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.HobbyFavorite)
                    .WithMany(p => p.PersonHobbyFavorites)
                    .HasForeignKey(d => d.HobbyFavoriteId)
                    .HasConstraintName("FK__PersonHob__Hobby__74444068");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHobbyFavorites)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHob__Perso__73501C2F");
            });

            modelBuilder.Entity<PersonLanguage>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PersonLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonLan__Langu__7814D14C");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonLanguages)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonLan__Perso__7720AD13");
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

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.PersonPrivateInformationCastes)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK__PersonPri__Caste__4B422AD5");

                entity.HasOne(d => d.ParentalStatus)
                    .WithMany(p => p.PersonPrivateInformationParentalStatus)
                    .HasForeignKey(d => d.ParentalStatusId)
                    .HasConstraintName("FK__PersonPri__Paren__4C364F0E");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPrivateInformations)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonPri__Perso__477199F1");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.PersonPrivateInformationReligions)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK__PersonPri__Relig__4A4E069C");
            });

            modelBuilder.Entity<PersonSocialMediaAccount>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Link)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.PersonSocialMediaAccountAccountTypes)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__Accou__7CD98669");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonSocialMediaAccounts)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__Perso__7BE56230");

                entity.HasOne(d => d.TypeOfUser)
                    .WithMany(p => p.PersonSocialMediaAccountTypeOfUsers)
                    .HasForeignKey(d => d.TypeOfUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonSoc__TypeO__7DCDAAA2");
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

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.LongText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.PersonWorkExperienceIndustries)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonWor__Indus__019E3B86");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonWorkExperiences)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonWor__Perso__00AA174D");

                entity.HasOne(d => d.WorkType)
                    .WithMany(p => p.PersonWorkExperienceWorkTypes)
                    .HasForeignKey(d => d.WorkTypeId)
                    .HasConstraintName("FK__PersonWor__WorkT__02925FBF");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Programs__Organi__084B3915");
            });

            modelBuilder.Entity<ProgramAttendance>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ProgramAttendances)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProgramAt__Perso__0E04126B");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramAttendances)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProgramAt__Progr__0EF836A4");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__States__CountryI__24285DB4");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tickets__PersonI__0B27A5C0");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedById).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById).HasMaxLength(450);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Universities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Universit__CityI__056ECC6A");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
