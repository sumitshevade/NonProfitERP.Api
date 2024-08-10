using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class PersonFamilyDetailMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.PersonFamilyDetail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.PersonFamilyDetail> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonFamilyDetails", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("int");

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.MiddleName)
                .HasColumnName("MiddleName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date");

            builder.Property(t => t.MobileNo)
                .HasColumnName("MobileNo")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.OrganizationId)
                .HasColumnName("OrganizationId")
                .HasColumnType("int");

            builder.Property(t => t.OtherOrganization)
                .HasColumnName("OtherOrganization")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.SchoolName)
                .HasColumnName("SchoolName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.MonthlyIncome)
                .HasColumnName("MonthlyIncome")
                .HasColumnType("float");

            builder.Property(t => t.RelationId)
                .HasColumnName("RelationId")
                .HasColumnType("int");

            builder.Property(t => t.OtherRelation)
                .HasColumnName("OtherRelation")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.CourseId)
                .HasColumnName("CourseId")
                .HasColumnType("int");

            builder.Property(t => t.OtherCourse)
                .HasColumnName("OtherCourse")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.AnyDisability)
                .HasColumnName("AnyDisability")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.CreatedById)
                .IsRequired()
                .HasColumnName("CreatedById")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.UpdatedById)
                .HasColumnName("UpdatedById")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime");

            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            builder.HasOne(t => t.CourseDetail)
                .WithMany(t => t.CoursePersonFamilyDetails)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__PersonFam__Cours__5AB9788F");

            builder.HasOne(t => t.Organization)
                .WithMany(t => t.PersonFamilyDetails)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK__PersonFam__Organ__58D1301D");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonFamilyDetails)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonFam__Perso__57DD0BE4");

            builder.HasOne(t => t.RelationDetail)
                .WithMany(t => t.RelationPersonFamilyDetails)
                .HasForeignKey(d => d.RelationId)
                .HasConstraintName("FK__PersonFam__Relat__59C55456");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonFamilyDetail";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string FirstName = "FirstName";
            public const string MiddleName = "MiddleName";
            public const string LastName = "LastName";
            public const string BirthDate = "BirthDate";
            public const string MobileNo = "MobileNo";
            public const string Email = "Email";
            public const string OrganizationId = "OrganizationId";
            public const string OtherOrganization = "OtherOrganization";
            public const string SchoolName = "SchoolName";
            public const string MonthlyIncome = "MonthlyIncome";
            public const string RelationId = "RelationId";
            public const string OtherRelation = "OtherRelation";
            public const string CourseId = "CourseId";
            public const string OtherCourse = "OtherCourse";
            public const string AnyDisability = "AnyDisability";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
