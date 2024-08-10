using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class TransactionLogValueMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.TransactionLogValue>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.TransactionLogValue> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("TransactionLogValues", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TransactionLogId)
                .IsRequired()
                .HasColumnName("TransactionLogId")
                .HasColumnType("int");

            builder.Property(t => t.TableName)
                .IsRequired()
                .HasColumnName("TableName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.PreviousValue)
                .HasColumnName("PreviousValue")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.Property(t => t.NewValue)
                .HasColumnName("NewValue")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            // relationships
            builder.HasOne(t => t.TransactionLog)
                .WithMany(t => t.TransactionLogValues)
                .HasForeignKey(d => d.TransactionLogId)
                .HasConstraintName("FK__Transacti__Trans__3A81B327");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "TransactionLogValue";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string TransactionLogId = "TransactionLogId";
            public const string TableName = "TableName";
            public const string PreviousValue = "PreviousValue";
            public const string NewValue = "NewValue";
        }
        #endregion
    }
}
