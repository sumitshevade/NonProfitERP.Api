using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class DeviceCodesMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.DeviceCodes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.DeviceCodes> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("DeviceCodes", "dbo");

            // key
            builder.HasKey(t => t.UserCode);

            // properties
            builder.Property(t => t.UserCode)
                .IsRequired()
                .HasColumnName("UserCode")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.DeviceCode)
                .IsRequired()
                .HasColumnName("DeviceCode")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.SubjectId)
                .HasColumnName("SubjectId")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.ClientId)
                .IsRequired()
                .HasColumnName("ClientId")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.CreationTime)
                .IsRequired()
                .HasColumnName("CreationTime")
                .HasColumnType("datetime2");

            builder.Property(t => t.Expiration)
                .IsRequired()
                .HasColumnName("Expiration")
                .HasColumnType("datetime2");

            builder.Property(t => t.Data)
                .IsRequired()
                .HasColumnName("Data")
                .HasColumnType("nvarchar(max)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "DeviceCodes";
        }

        public struct Columns
        {
            public const string UserCode = "UserCode";
            public const string DeviceCode = "DeviceCode";
            public const string SubjectId = "SubjectId";
            public const string ClientId = "ClientId";
            public const string CreationTime = "CreationTime";
            public const string Expiration = "Expiration";
            public const string Data = "Data";
        }
        #endregion
    }
}
