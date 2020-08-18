using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class AspNetUserLoginsMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.AspNetUserLogins>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.AspNetUserLogins> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetUserLogins", "dbo");

            // key
            builder.HasKey(t => new { t.LoginProvider, t.ProviderKey });

            // properties
            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasColumnName("LoginProvider")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(t => t.ProviderKey)
                .IsRequired()
                .HasColumnName("ProviderKey")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(t => t.ProviderDisplayName)
                .HasColumnName("ProviderDisplayName")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            // relationships
            builder.HasOne(t => t.UserAspNetUsers)
                .WithMany(t => t.UserAspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "AspNetUserLogins";
        }

        public struct Columns
        {
            public const string LoginProvider = "LoginProvider";
            public const string ProviderKey = "ProviderKey";
            public const string ProviderDisplayName = "ProviderDisplayName";
            public const string UserId = "UserId";
        }
        #endregion
    }
}
