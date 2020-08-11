using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class DepartmentHeadMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.DepartmentHead>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.DepartmentHead> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("DepartmentHead", "dbo");

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

            builder.Property(t => t.DepartmentId)
                .IsRequired()
                .HasColumnName("DepartmentId")
                .HasColumnType("int");

            builder.Property(t => t.FromYear)
                .IsRequired()
                .HasColumnName("FromYear")
                .HasColumnType("int");

            builder.Property(t => t.ToYear)
                .HasColumnName("ToYear")
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

            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            builder.HasOne(t => t.Department)
                .WithMany(t => t.DepartmentHeads)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Departmen__Depar__07C12930");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.DepartmentHeads)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Departmen__Perso__06CD04F7");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "DepartmentHead";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string DepartmentId = "DepartmentId";
            public const string FromYear = "FromYear";
            public const string ToYear = "ToYear";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
