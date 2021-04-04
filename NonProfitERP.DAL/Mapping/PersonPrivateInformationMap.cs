using Microsoft.EntityFrameworkCore;

namespace PublicData.Data.Mapping
{
    public partial class PersonPrivateInformationMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonPrivateInformation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonPrivateInformation> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonPrivateInformation", "dbo");

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

            builder.Property(t => t.MaritalStatus)
                .IsRequired()
                .HasColumnName("MaritalStatus")
                .HasColumnType("int");

            builder.Property(t => t.AadharCardNo)
                .HasColumnName("AadharCardNo")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(t => t.PANNo)
                .HasColumnName("PANNo")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(t => t.IsOwnBicycle)
                .IsRequired()
                .HasColumnName("IsOwnBicycle")
                .HasColumnType("bit");

            builder.Property(t => t.ReligionId)
                .HasColumnName("ReligionId")
                .HasColumnType("int");

            builder.Property(t => t.OtherReligion)
                .HasColumnName("OtherReligion")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.CasteId)
                .HasColumnName("CasteId")
                .HasColumnType("int");

            builder.Property(t => t.OtherCaste)
                .HasColumnName("OtherCaste")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("int");

            builder.Property(t => t.OtherCategory)
                .HasColumnName("OtherCategory")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ParentalStatusId)
                .HasColumnName("ParentalStatusId")
                .HasColumnType("int");

            builder.Property(t => t.OtherParentalStatus)
                .HasColumnName("OtherParentalStatus")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

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

            builder.Property(t => t.IsAlive)
                .IsRequired()
                .HasColumnName("IsAlive")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            builder.Property(t => t.DateOfExpiry)
                .HasColumnName("DateOfExpiry")
                .HasColumnType("date");

            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            builder.HasOne(t => t.CasteDetail)
                .WithMany(t => t.CastePersonPrivateInformations)
                .HasForeignKey(d => d.CasteId)
                .HasConstraintName("FK__PersonPri__Caste__72910220");

            builder.HasOne(t => t.CategoryDetail)
                .WithMany(t => t.CategoryPersonPrivateInformations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__PersonPri__Categ__73852659");

            builder.HasOne(t => t.ParentalStatusDetail)
                .WithMany(t => t.ParentalStatusPersonPrivateInformations)
                .HasForeignKey(d => d.ParentalStatusId)
                .HasConstraintName("FK__PersonPri__Paren__74794A92");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonPrivateInformations)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonPri__Perso__70A8B9AE");

            builder.HasOne(t => t.ReligionDetail)
                .WithMany(t => t.ReligionPersonPrivateInformations)
                .HasForeignKey(d => d.ReligionId)
                .HasConstraintName("FK__PersonPri__Relig__719CDDE7");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonPrivateInformation";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string MaritalStatus = "MaritalStatus";
            public const string AadharCardNo = "AadharCardNo";
            public const string PANNo = "PANNo";
            public const string IsOwnBicycle = "IsOwnBicycle";
            public const string ReligionId = "ReligionId";
            public const string OtherReligion = "OtherReligion";
            public const string CasteId = "CasteId";
            public const string OtherCaste = "OtherCaste";
            public const string CategoryId = "CategoryId";
            public const string OtherCategory = "OtherCategory";
            public const string ParentalStatusId = "ParentalStatusId";
            public const string OtherParentalStatus = "OtherParentalStatus";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsAlive = "IsAlive";
            public const string DateOfExpiry = "DateOfExpiry";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
