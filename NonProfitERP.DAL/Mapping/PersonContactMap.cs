using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NonProfitERP.Data.Mapping
{
    public partial class PersonContactMap
        : IEntityTypeConfiguration<NonProfitERP.DAL.Entities.PersonContact>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NonProfitERP.DAL.Entities.PersonContact> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonContacts", "dbo");

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

            builder.Property(t => t.ContactTypeId)
                .HasColumnName("ContactTypeId")
                .HasColumnType("int");

            builder.Property(t => t.Detail)
                .HasColumnName("Detail")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.IsDefault)
                .IsRequired()
                .HasColumnName("IsDefault")
                .HasColumnType("bit");

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
            builder.HasOne(t => t.ContactTypeDetail)
                .WithMany(t => t.ContactTypePersonContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .HasConstraintName("FK__PersonCon__Conta__37703C52");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonContacts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonCon__Perso__367C1819");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonContact";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string ContactTypeId = "ContactTypeId";
            public const string Detail = "Detail";
            public const string IsDefault = "IsDefault";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
