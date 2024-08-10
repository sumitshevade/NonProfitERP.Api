using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class PersonLanguageMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.PersonLanguage>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.PersonLanguage> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonLanguages", "dbo");

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

            builder.Property(t => t.LanguageId)
                .HasColumnName("LanguageId")
                .HasColumnType("int");

            builder.Property(t => t.OtherLanguage)
                .HasColumnName("OtherLanguage")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.IsMotherTongue)
                .IsRequired()
                .HasColumnName("IsMotherTongue")
                .HasColumnType("bit");

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
            builder.HasOne(t => t.LanguageDetail)
                .WithMany(t => t.LanguagePersonLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__PersonLan__Langu__6AEFE058");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonLanguages)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonLan__Perso__69FBBC1F");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonLanguage";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string LanguageId = "LanguageId";
            public const string OtherLanguage = "OtherLanguage";
            public const string IsMotherTongue = "IsMotherTongue";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
