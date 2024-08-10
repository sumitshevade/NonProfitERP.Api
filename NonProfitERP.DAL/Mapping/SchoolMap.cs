using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class SchoolMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.School>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.School> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Schools", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.ContactPersonName)
                .HasColumnName("ContactPersonName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ContactPersonDesignation)
                .HasColumnName("ContactPersonDesignation")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ContactPersonContactNo)
                .HasColumnName("ContactPersonContactNo")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.AddressLine2)
                .HasColumnName("AddressLine2")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.TalukaId)
                .HasColumnName("TalukaId")
                .HasColumnType("int");

            builder.Property(t => t.OtherTaluka)
                .HasColumnName("OtherTaluka")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.DistrictId)
                .HasColumnName("DistrictId")
                .HasColumnType("int");

            builder.Property(t => t.OtherDistrict)
                .HasColumnName("OtherDistrict")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.StateId)
                .HasColumnName("StateId")
                .HasColumnType("int");

            builder.Property(t => t.PhoneNo)
                .HasColumnName("PhoneNo")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.WebLink)
                .HasColumnName("WebLink")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.SchoolTypeId)
                .HasColumnName("SchoolTypeId")
                .HasColumnType("int");

            builder.Property(t => t.LongText)
                .HasColumnName("LongText")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

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
            builder.HasOne(t => t.District)
                .WithMany(t => t.Schools)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__School__District__41EDCAC5");

            builder.HasOne(t => t.TypeDetail)
                .WithMany(t => t.TypeSchools)
                .HasForeignKey(d => d.SchoolTypeId)
                .HasConstraintName("FK__School__SchoolTy__43D61337");

            builder.HasOne(t => t.State)
                .WithMany(t => t.Schools)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__School__StateId__42E1EEFE");

            builder.HasOne(t => t.Taluka)
                .WithMany(t => t.Schools)
                .HasForeignKey(d => d.TalukaId)
                .HasConstraintName("FK__School__TalukaId__40F9A68C");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "School";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string ContactPersonName = "ContactPersonName";
            public const string ContactPersonDesignation = "ContactPersonDesignation";
            public const string ContactPersonContactNo = "ContactPersonContactNo";
            public const string AddressLine1 = "AddressLine1";
            public const string AddressLine2 = "AddressLine2";
            public const string TalukaId = "TalukaId";
            public const string OtherTaluka = "OtherTaluka";
            public const string DistrictId = "DistrictId";
            public const string OtherDistrict = "OtherDistrict";
            public const string StateId = "StateId";
            public const string PhoneNo = "PhoneNo";
            public const string Email = "Email";
            public const string WebLink = "WebLink";
            public const string SchoolTypeId = "SchoolTypeId";
            public const string LongText = "LongText";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
