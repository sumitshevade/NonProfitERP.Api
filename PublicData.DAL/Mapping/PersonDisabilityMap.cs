using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData30102020.Data.Mapping
{
    public partial class PersonDisabilityMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonDisability>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonDisability> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonDisability", "dbo");

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

            builder.Property(t => t.Problem)
                .IsRequired()
                .HasColumnName("Problem")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Detail)
                .HasColumnName("Detail")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder.Property(t => t.FromYear)
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
                .WithMany(t => t.PersonDisabilities)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonDis__Perso__3C34F16F");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonDisability";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string Problem = "Problem";
            public const string Detail = "Detail";
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
