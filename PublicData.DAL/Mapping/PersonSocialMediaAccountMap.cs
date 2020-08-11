using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonSocialMediaAccountMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonSocialMediaAccount>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonSocialMediaAccount> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonSocialMediaAccount", "dbo");

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

            builder.Property(t => t.AccountTypeId)
                .IsRequired()
                .HasColumnName("AccountTypeId")
                .HasColumnType("int");

            builder.Property(t => t.OtherAccountType)
                .HasColumnName("OtherAccountType")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Link)
                .HasColumnName("Link")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.TypeOfUserId)
                .IsRequired()
                .HasColumnName("TypeOfUserId")
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
            builder.HasOne(t => t.AccountTypeDetail)
                .WithMany(t => t.AccountTypePersonSocialMediaAccounts)
                .HasForeignKey(d => d.AccountTypeId)
                .HasConstraintName("FK__PersonSoc__Accou__5F7E2DAC");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonSocialMediaAccounts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonSoc__Perso__5E8A0973");

            builder.HasOne(t => t.TypeOfUserDetail)
                .WithMany(t => t.TypeOfUserPersonSocialMediaAccounts)
                .HasForeignKey(d => d.TypeOfUserId)
                .HasConstraintName("FK__PersonSoc__TypeO__607251E5");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonSocialMediaAccount";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string AccountTypeId = "AccountTypeId";
            public const string OtherAccountType = "OtherAccountType";
            public const string Link = "Link";
            public const string TypeOfUserId = "TypeOfUserId";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
