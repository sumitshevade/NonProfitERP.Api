using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class BatchMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.Batch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.Batch> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Batches", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.CourseId)
                .IsRequired()
                .HasColumnName("CourseId")
                .HasColumnType("int");

            builder.Property(t => t.StartDate)
                .IsRequired()
                .HasColumnName("StartDate")
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("date");

            builder.Property(t => t.Year)
                .HasColumnName("Year")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(t => t.ContactNo)
                .HasColumnName("ContactNo")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

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
            builder.HasOne(t => t.Course)
                .WithMany(t => t.Batches)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Batch__CourseId__17F790F9");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Batch";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string CourseId = "CourseId";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string Year = "Year";
            public const string ContactNo = "ContactNo";
            public const string Email = "Email";
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
