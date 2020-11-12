using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.Data.Mapping
{
    public partial class DetailMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.Detail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.Detail> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Detail", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.HeaderId)
                .IsRequired()
                .HasColumnName("HeaderId")
                .HasColumnType("int");

            builder.Property(t => t.Value)
                .IsRequired()
                .HasColumnName("Value")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.ExtraField)
                .HasColumnName("ExtraField")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

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
            builder.HasOne(t => t.Header)
                .WithMany(t => t.Details)
                .HasForeignKey(d => d.HeaderId)
                .HasConstraintName("FK__Detail__HeaderId__5812160E");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Detail";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string HeaderId = "HeaderId";
            public const string Value = "Value";
            public const string ExtraField = "ExtraField";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
