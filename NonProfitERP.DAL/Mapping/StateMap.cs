using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class StateMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.State>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.State> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("States", "dbo");

            // key
            builder.HasKey(t => t.Id)
                .HasName("PK__States__3214EC07B0873B68");

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.CountryId)
                .IsRequired()
                .HasColumnName("CountryId")
                .HasColumnType("int");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsUnicode(false);

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
                .HasDefaultValue(true);

            // relationships
            builder.HasOne(t => t.Country)
                .WithMany(t => t.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__States__CountryI__29E1370A");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "State";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string CountryId = "CountryId";
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
