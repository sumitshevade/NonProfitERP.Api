using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonEducationMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonEducation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonEducation> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonEducation", "dbo");

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

            builder.Property(t => t.SchoolId)
                .HasColumnName("SchoolId")
                .HasColumnType("int");

            builder.Property(t => t.OtherSchool)
                .HasColumnName("OtherSchool")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.FromStdId)
                .HasColumnName("FromStdId")
                .HasColumnType("int");

            builder.Property(t => t.ToStdId)
                .HasColumnName("ToStdId")
                .HasColumnType("int");

            builder.Property(t => t.MediumId)
                .HasColumnName("MediumId")
                .HasColumnType("int");

            builder.Property(t => t.OtherMedium)
                .HasColumnName("OtherMedium")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.FromYear)
                .IsRequired()
                .HasColumnName("FromYear")
                .HasColumnType("int");

            builder.Property(t => t.ToYear)
                .HasColumnName("ToYear")
                .HasColumnType("int");

            builder.Property(t => t.UniversityBoardId)
                .HasColumnName("UniversityBoardId")
                .HasColumnType("int");

            builder.Property(t => t.OtherUniversityBoard)
                .HasColumnName("OtherUniversityBoard")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.DegreeId)
                .HasColumnName("DegreeId")
                .HasColumnType("int");

            builder.Property(t => t.OtherDegree)
                .HasColumnName("OtherDegree")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.CourseId)
                .HasColumnName("CourseId")
                .HasColumnType("int");

            builder.Property(t => t.OtherCourse)
                .HasColumnName("OtherCourse")
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
                .WithMany(t => t.CoursePersonEducations)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__PersonEdu__Cours__40058253");

            builder.HasOne(t => t.DegreeDetail)
                .WithMany(t => t.DegreePersonEducations)
                .HasForeignKey(d => d.DegreeId)
                .HasConstraintName("FK__PersonEdu__Degre__3F115E1A");

            builder.HasOne(t => t.FromStdDetail)
                .WithMany(t => t.FromStdPersonEducations)
                .HasForeignKey(d => d.FromStdId)
                .HasConstraintName("FK__PersonEdu__FromS__3B40CD36");

            builder.HasOne(t => t.MediumDetail)
                .WithMany(t => t.MediumPersonEducations)
                .HasForeignKey(d => d.MediumId)
                .HasConstraintName("FK__PersonEdu__Mediu__3D2915A8");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonEducations)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonEdu__Perso__395884C4");

            builder.HasOne(t => t.School)
                .WithMany(t => t.PersonEducations)
                .HasForeignKey(d => d.SchoolId)
                .HasConstraintName("FK__PersonEdu__Schoo__3A4CA8FD");

            builder.HasOne(t => t.ToStdDetail)
                .WithMany(t => t.ToStdPersonEducations)
                .HasForeignKey(d => d.ToStdId)
                .HasConstraintName("FK__PersonEdu__ToStd__3C34F16F");

            builder.HasOne(t => t.UniversityBoardDetail)
                .WithMany(t => t.UniversityBoardPersonEducations)
                .HasForeignKey(d => d.UniversityBoardId)
                .HasConstraintName("FK__PersonEdu__Unive__3E1D39E1");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonEducation";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string SchoolId = "SchoolId";
            public const string OtherSchool = "OtherSchool";
            public const string FromStdId = "FromStdId";
            public const string ToStdId = "ToStdId";
            public const string MediumId = "MediumId";
            public const string OtherMedium = "OtherMedium";
            public const string FromYear = "FromYear";
            public const string ToYear = "ToYear";
            public const string UniversityBoardId = "UniversityBoardId";
            public const string OtherUniversityBoard = "OtherUniversityBoard";
            public const string DegreeId = "DegreeId";
            public const string OtherDegree = "OtherDegree";
            public const string CourseId = "CourseId";
            public const string OtherCourse = "OtherCourse";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
