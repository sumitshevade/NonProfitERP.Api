using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.Data.Mapping
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

            builder.Property(t => t.OrganizationId)
                .HasColumnName("OrganizationId")
                .HasColumnType("int");

            builder.Property(t => t.OtherOrganization)
                .HasColumnName("OtherOrganization")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.WorkTypeId)
                .HasColumnName("WorkTypeId")
                .HasColumnType("int");

            builder.Property(t => t.OtherWorkType)
                .HasColumnName("OtherWorkType")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.DepartmentId)
                .HasColumnName("DepartmentId")
                .HasColumnType("int");

            builder.Property(t => t.OtherDepartment)
                .HasColumnName("OtherDepartment")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.DesignationId)
                .HasColumnName("DesignationId")
                .HasColumnType("int");

            builder.Property(t => t.OtherDesignation)
                .HasColumnName("OtherDesignation")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.FromYear)
                .HasColumnName("FromYear")
                .HasColumnType("int");

            builder.Property(t => t.ToYear)
                .HasColumnName("ToYear")
                .HasColumnType("int");

            builder.Property(t => t.Specialization)
                .HasColumnName("Specialization")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.IsFreeLance)
                .HasColumnName("IsFreeLance")
                .HasColumnType("bit");

            builder.Property(t => t.IsFullTime)
                .HasColumnName("IsFullTime")
                .HasColumnType("bit");

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
            builder.HasOne(t => t.DepartmentDetail)
                .WithMany(t => t.DepartmentPersonWorkExperiences)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__PersonWor__Depar__02C769E9");

            builder.HasOne(t => t.DesignationDetail)
                .WithMany(t => t.DesignationPersonWorkExperiences)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK__PersonWor__Desig__03BB8E22");

            builder.HasOne(t => t.Organization)
                .WithMany(t => t.PersonWorkExperiences)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK__PersonWor__Organ__00DF2177");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonWorkExperiences)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonWor__Perso__7FEAFD3E");

            builder.HasOne(t => t.WorkTypeDetail)
                .WithMany(t => t.WorkTypePersonWorkExperiences)
                .HasForeignKey(d => d.WorkTypeId)
                .HasConstraintName("FK__PersonWor__WorkT__01D345B0");

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
            public const string OrganizationId = "OrganizationId";
            public const string OtherOrganization = "OtherOrganization";
            public const string WorkTypeId = "WorkTypeId";
            public const string OtherWorkType = "OtherWorkType";
            public const string DepartmentId = "DepartmentId";
            public const string OtherDepartment = "OtherDepartment";
            public const string DesignationId = "DesignationId";
            public const string OtherDesignation = "OtherDesignation";
            public const string FromYear = "FromYear";
            public const string ToYear = "ToYear";
            public const string Specialization = "Specialization";
            public const string IsFreeLance = "IsFreeLance";
            public const string IsFullTime = "IsFullTime";
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
