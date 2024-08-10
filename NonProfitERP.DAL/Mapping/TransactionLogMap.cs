using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class TransactionLogMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.TransactionLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.TransactionLog> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("TransactionLogs", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.OperationType)
                .IsRequired()
                .HasColumnName("OperationType")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "TransactionLog";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string UserId = "UserId";
            public const string OperationType = "OperationType";
            public const string CreatedAt = "CreatedAt";
        }
        #endregion
    }
}
