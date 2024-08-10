using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class PersonProgramMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.PersonProgram>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.PersonProgram> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonPrograms", "dbo");

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

            builder.Property(t => t.ProgramId)
                .IsRequired()
                .HasColumnName("ProgramId")
                .HasColumnType("int");

            builder.Property(t => t.Role)
                .HasColumnName("Role")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(t => t.StartDate)
                .IsRequired()
                .HasColumnName("StartDate")
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("date");

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
            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonPrograms)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonPro__Perso__75A278F5");

            builder.HasOne(t => t.Program)
                .WithMany(t => t.PersonPrograms)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__PersonPro__Progr__76969D2E");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonProgram";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string ProgramId = "ProgramId";
            public const string Role = "Role";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
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
