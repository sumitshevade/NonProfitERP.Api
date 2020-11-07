using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.Data.Mapping
{
    public partial class CourseMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.Course> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Course", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.DepartmentId)
                .HasColumnName("DepartmentId")
                .HasColumnType("int");

            builder.Property(t => t.ProgramId)
                .HasColumnName("ProgramId")
                .HasColumnType("int");

            builder.Property(t => t.SubProgramId)
                .HasColumnName("SubProgramId")
                .HasColumnType("int");

            builder.Property(t => t.HeadId)
                .HasColumnName("HeadId")
                .HasColumnType("int");

            builder.Property(t => t.CourseName)
                .IsRequired()
                .HasColumnName("CourseName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.StartDate)
                .IsRequired()
                .HasColumnName("StartDate")
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("date");

            builder.Property(t => t.ContactNo)
                .HasColumnName("ContactNo")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.LongText)
                .HasColumnName("LongText")
                .HasColumnType("varchar(500)")
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
            builder.HasOne(t => t.Department)
                .WithMany(t => t.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Course__Departme__08B54D69");

            builder.HasOne(t => t.HeadPerson)
                .WithMany(t => t.HeadCourses)
                .HasForeignKey(d => d.HeadId)
                .HasConstraintName("FK__Course__HeadId__0B91BA14");

            builder.HasOne(t => t.Program)
                .WithMany(t => t.Courses)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__Course__ProgramI__09A971A2");

            builder.HasOne(t => t.SubProgram)
                .WithMany(t => t.Courses)
                .HasForeignKey(d => d.SubProgramId)
                .HasConstraintName("FK__Course__SubProgr__0A9D95DB");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Course";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string DepartmentId = "DepartmentId";
            public const string ProgramId = "ProgramId";
            public const string SubProgramId = "SubProgramId";
            public const string HeadId = "HeadId";
            public const string CourseName = "CourseName";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string ContactNo = "ContactNo";
            public const string Email = "Email";
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
