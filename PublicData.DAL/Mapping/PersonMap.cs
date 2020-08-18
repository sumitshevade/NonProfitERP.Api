using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.Person>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.Person> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Person", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.LoginId)
                .HasColumnName("LoginId")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.PersonTypeId)
                .IsRequired()
                .HasColumnName("PersonTypeId")
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

            builder.Property(t => t.BirthLocation)
                .HasColumnName("BirthLocation")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.LongText)
                .HasColumnName("LongText")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.Property(t => t.Keywords)
                .HasColumnName("Keywords")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder.Property(t => t.IsWorker)
                .IsRequired()
                .HasColumnName("IsWorker")
                .HasColumnType("bit");

            builder.Property(t => t.WorkFrequencyId)
                .IsRequired()
                .HasColumnName("WorkFrequencyId")
                .HasColumnType("int");

            builder.Property(t => t.JoiningDate)
                .HasColumnName("JoiningDate")
                .HasColumnType("date");

            builder.Property(t => t.JoinedAsId)
                .HasColumnName("JoinedAsId")
                .HasColumnType("int");

            builder.Property(t => t.CountryId)
                .HasColumnName("CountryId")
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
            builder.HasOne(t => t.Country)
                .WithMany(t => t.People)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Person__CountryI__02084FDA");

            builder.HasOne(t => t.TypeDetail)
                .WithMany(t => t.TypePeople)
                .HasForeignKey(d => d.PersonTypeId)
                .HasConstraintName("FK__Person__PersonTy__00200768");

            builder.HasOne(t => t.WorkFrequencyDetail)
                .WithMany(t => t.WorkFrequencyPeople)
                .HasForeignKey(d => d.WorkFrequencyId)
                .HasConstraintName("FK__Person__WorkFreq__01142BA1");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Person";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string LoginId = "LoginId";
            public const string PersonTypeId = "PersonTypeId";
            public const string FirstName = "FirstName";
            public const string MiddleName = "MiddleName";
            public const string LastName = "LastName";
            public const string BirthDate = "BirthDate";
            public const string BirthLocation = "BirthLocation";
            public const string LongText = "LongText";
            public const string Keywords = "Keywords";
            public const string IsWorker = "IsWorker";
            public const string WorkFrequencyId = "WorkFrequencyId";
            public const string JoiningDate = "JoiningDate";
            public const string JoinedAsId = "JoinedAsId";
            public const string CountryId = "CountryId";
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
