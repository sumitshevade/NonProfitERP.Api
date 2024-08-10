using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class CourseHeadMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.CourseHead>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.CourseHead> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("CourseHeads", "dbo");

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
                .WithMany(t => t.CourseHeads)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__CourseHea__Cours__123EB7A3");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.CourseHeads)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__CourseHea__Perso__114A936A");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "CourseHead";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string CourseId = "CourseId";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
