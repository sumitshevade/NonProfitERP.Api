using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonWorkExperienceMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonWorkExperience>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonWorkExperience> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonWorkExperience", "dbo");

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

            builder.Property(t => t.IndustryId)
                .IsRequired()
                .HasColumnName("IndustryId")
                .HasColumnType("int");

            builder.Property(t => t.OtherIndustry)
                .HasColumnName("OtherIndustry")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.WorkTypeId)
                .HasColumnName("WorkTypeId")
                .HasColumnType("int");

            builder.Property(t => t.OtherWorkType)
                .HasColumnName("OtherWorkType")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.StatusId)
                .HasColumnName("StatusId")
                .HasColumnType("int");

            builder.Property(t => t.OtherStatus)
                .HasColumnName("OtherStatus")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ActualWork)
                .HasColumnName("ActualWork")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.FromYear)
                .HasColumnName("FromYear")
                .HasColumnType("int");

            builder.Property(t => t.ToYear)
                .HasColumnName("ToYear")
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
            builder.HasOne(t => t.IndustryDetail)
                .WithMany(t => t.IndustryPersonWorkExperiences)
                .HasForeignKey(d => d.IndustryId)
                .HasConstraintName("FK__PersonWor__Indus__65370702");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonWorkExperiences)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonWor__Perso__6442E2C9");

            builder.HasOne(t => t.StatusDetail)
                .WithMany(t => t.StatusPersonWorkExperiences)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__PersonWor__Statu__671F4F74");

            builder.HasOne(t => t.WorkTypeDetail)
                .WithMany(t => t.WorkTypePersonWorkExperiences)
                .HasForeignKey(d => d.WorkTypeId)
                .HasConstraintName("FK__PersonWor__WorkT__662B2B3B");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonWorkExperience";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string IndustryId = "IndustryId";
            public const string OtherIndustry = "OtherIndustry";
            public const string WorkTypeId = "WorkTypeId";
            public const string OtherWorkType = "OtherWorkType";
            public const string StatusId = "StatusId";
            public const string OtherStatus = "OtherStatus";
            public const string CompanyName = "CompanyName";
            public const string ActualWork = "ActualWork";
            public const string FromYear = "FromYear";
            public const string ToYear = "ToYear";
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
