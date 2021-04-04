using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class OrganizationMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.Organization>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.Organization> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Organization", "dbo");

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

            builder.Property(t => t.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.AddressLine2)
                .HasColumnName("AddressLine2")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.WebLink)
                .HasColumnName("WebLink")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ContactNo)
                .HasColumnName("ContactNo")
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

            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Organization";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string AddressLine1 = "AddressLine1";
            public const string AddressLine2 = "AddressLine2";
            public const string WebLink = "WebLink";
            public const string ContactNo = "ContactNo";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
