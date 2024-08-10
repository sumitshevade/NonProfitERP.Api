using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class CountryMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.Country>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.Country> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Countries", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
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
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Country";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
