using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.DAL.Mapping
{
    public partial class PersistedGrantsMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.PersistedGrants>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.PersistedGrants> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersistedGrants", "dbo");

            // key
            builder.HasKey(t => t.Key);

            // properties
            builder.Property(t => t.Key)
                .IsRequired()
                .HasColumnName("Key")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

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
            public const string Name = "PersistedGrants";
        }

        public struct Columns
        {
            public const string Key = "Key";
            public const string Type = "Type";
            public const string SubjectId = "SubjectId";
            public const string ClientId = "ClientId";
            public const string CreationTime = "CreationTime";
            public const string Expiration = "Expiration";
            public const string Data = "Data";
        }
        #endregion
    }
}
