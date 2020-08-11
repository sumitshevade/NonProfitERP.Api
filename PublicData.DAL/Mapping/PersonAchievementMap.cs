using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonAchievementMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonAchievement>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonAchievement> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonAchievement", "dbo");

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

            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.GivenBy)
                .HasColumnName("GivenBy")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.Format)
                .HasColumnName("Format")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Reason)
                .HasColumnName("Reason")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.AwardLevelId)
                .HasColumnName("AwardLevelId")
                .HasColumnType("int");

            builder.Property(t => t.ReceivedDate)
                .HasColumnName("ReceivedDate")
                .HasColumnType("date");

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
            builder.HasOne(t => t.AwardLevelDetail)
                .WithMany(t => t.AwardLevelPersonAchievements)
                .HasForeignKey(d => d.AwardLevelId)
                .HasConstraintName("FK__PersonAch__Award__151B244E");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonAchievements)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonAch__Perso__14270015");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonAchievement";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string Title = "Title";
            public const string GivenBy = "GivenBy";
            public const string Format = "Format";
            public const string Reason = "Reason";
            public const string AwardLevelId = "AwardLevelId";
            public const string ReceivedDate = "ReceivedDate";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
