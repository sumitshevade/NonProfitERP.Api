using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData30102020.Data.Mapping
{
    public partial class TicketMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.Ticket>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.Ticket> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Ticket", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.EventId)
                .IsRequired()
                .HasColumnName("EventId")
                .HasColumnType("int");

            builder.Property(t => t.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("int");

            builder.Property(t => t.TicketCount)
                .IsRequired()
                .HasColumnName("TicketCount")
                .HasColumnType("int")
                .HasDefaultValueSql("((1))");

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
            builder.HasOne(t => t.Event)
                .WithMany(t => t.Tickets)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Ticket__EventId__1209AD79");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.Tickets)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Ticket__PersonId__12FDD1B2");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Ticket";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string EventId = "EventId";
            public const string PersonId = "PersonId";
            public const string TicketCount = "TicketCount";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
