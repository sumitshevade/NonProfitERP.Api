using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class PersonHobbyFavoriteMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.PersonHobbyFavorite>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.PersonHobbyFavorite> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonHobbyFavorite", "dbo");

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

            builder.Property(t => t.HobbyFavoriteId)
                .HasColumnName("HobbyFavoriteId")
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
            builder.HasOne(t => t.HobbyFavoriteDetail)
                .WithMany(t => t.HobbyFavoritePersonHobbyFavorites)
                .HasForeignKey(d => d.HobbyFavoriteId)
                .HasConstraintName("FK__PersonHob__Hobby__65370702");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonHobbyFavorites)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonHob__Perso__6442E2C9");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonHobbyFavorite";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string HobbyFavoriteId = "HobbyFavoriteId";
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
