using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class SchoolMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.School>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.School> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("School", "dbo");

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

            builder.Property(t => t.ContactPersonContactNo)
                .HasColumnName("ContactPersonContactNo")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Address)
                .HasColumnName("Address")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder.Property(t => t.PhoneNo)
                .HasColumnName("PhoneNo")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Website)
                .HasColumnName("Website")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.SchoolTypeId)
                .HasColumnName("SchoolTypeId")
                .HasColumnType("int");

            builder.Property(t => t.CreatedById)
                .IsRequired()
                .HasColumnName("CreatedById")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

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
            builder.HasOne(t => t.TypeDetail)
                .WithMany(t => t.TypeSchools)
                .HasForeignKey(d => d.SchoolTypeId)
                .HasConstraintName("FK__School__SchoolTy__3587F3E0");

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
            public const string ContactPersonContactNo = "ContactPersonContactNo";
            public const string Address = "Address";
            public const string PhoneNo = "PhoneNo";
            public const string Email = "Email";
            public const string Website = "Website";
            public const string SchoolTypeId = "SchoolTypeId";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
