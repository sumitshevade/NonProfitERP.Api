using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonFamilyDetailMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonFamilyDetail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonFamilyDetail> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonFamilyDetail", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

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

            builder.Property(t => t.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.SchoolName)
                .HasColumnName("SchoolName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.MonthlyIncome)
                .HasColumnName("MonthlyIncome")
                .HasColumnType("float");

            builder.Property(t => t.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("int");

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
            builder.HasOne(t => t.CourseDetail)
                .WithMany(t => t.CoursePersonFamilyDetails)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__PersonFam__Cours__45BE5BA9");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonFamilyDetails)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonFam__Perso__43D61337");

            builder.HasOne(t => t.RelationDetail)
                .WithMany(t => t.RelationPersonFamilyDetails)
                .HasForeignKey(d => d.RelationId)
                .HasConstraintName("FK__PersonFam__Relat__44CA3770");

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
            public const string FirstName = "FirstName";
            public const string MiddleName = "MiddleName";
            public const string LastName = "LastName";
            public const string BirthDate = "BirthDate";
            public const string MobileNo = "MobileNo";
            public const string Email = "Email";
            public const string CompanyName = "CompanyName";
            public const string SchoolName = "SchoolName";
            public const string MonthlyIncome = "MonthlyIncome";
            public const string PersonId = "PersonId";
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
