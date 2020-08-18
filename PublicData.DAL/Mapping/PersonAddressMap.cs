using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublicData.DAL.Mapping
{
    public partial class PersonAddressMap
        : IEntityTypeConfiguration<PublicData.DAL.Entities.PersonAddress>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PublicData.DAL.Entities.PersonAddress> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PersonAddress", "dbo");

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

            builder.Property(t => t.CountryId)
                .HasColumnName("CountryId")
                .HasColumnType("int");

            builder.Property(t => t.StateId)
                .HasColumnName("StateId")
                .HasColumnType("int");

            builder.Property(t => t.CityId)
                .HasColumnName("CityId")
                .HasColumnType("int");

            builder.Property(t => t.OtherCity)
                .HasColumnName("OtherCity")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.TalukaId)
                .HasColumnName("TalukaId")
                .HasColumnType("int");

            builder.Property(t => t.OtherTaluka)
                .HasColumnName("OtherTaluka")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.DistrictId)
                .HasColumnName("DistrictId")
                .HasColumnType("int");

            builder.Property(t => t.OtherDistrict)
                .HasColumnName("OtherDistrict")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Village)
                .HasColumnName("Village")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.IsPermanent)
                .IsRequired()
                .HasColumnName("IsPermanent")
                .HasColumnType("bit");

            builder.Property(t => t.RoadName)
                .HasColumnName("RoadName")
                .HasColumnType("varchar(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Line1)
                .HasColumnName("Line1")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.Line2)
                .HasColumnName("Line2")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(t => t.FromYear)
                .HasColumnName("FromYear")
                .HasColumnType("int");

            builder.Property(t => t.ToYear)
                .HasColumnName("ToYear")
                .HasColumnType("int");

            builder.Property(t => t.RoomsInHome)
                .HasColumnName("RoomsInHome")
                .HasColumnType("int");

            builder.Property(t => t.IsGovtBuildUp)
                .IsRequired()
                .HasColumnName("IsGovtBuildUp")
                .HasColumnType("bit");

            builder.Property(t => t.HomeStatusId)
                .HasColumnName("HomeStatusId")
                .HasColumnType("int");

            builder.Property(t => t.LocalityClassId)
                .HasColumnName("LocalityClassId")
                .HasColumnType("int");

            builder.Property(t => t.ResidentialStatusId)
                .HasColumnName("ResidentialStatusId")
                .HasColumnType("int");

            builder.Property(t => t.ResidentialAreaId)
                .HasColumnName("ResidentialAreaId")
                .HasColumnType("int");

            builder.Property(t => t.CreatedById)
                .IsRequired()
                .HasColumnName("CreatedById")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

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
            builder.HasOne(t => t.City)
                .WithMany(t => t.PersonAddresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__PersonAdd__CityI__236943A5");

            builder.HasOne(t => t.Country)
                .WithMany(t => t.PersonAddresses)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__PersonAdd__Count__2180FB33");

            builder.HasOne(t => t.District)
                .WithMany(t => t.PersonAddresses)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__PersonAdd__Distr__25518C17");

            builder.HasOne(t => t.HomeStatusDetail)
                .WithMany(t => t.HomeStatusPersonAddresses)
                .HasForeignKey(d => d.HomeStatusId)
                .HasConstraintName("FK__PersonAdd__HomeS__2645B050");

            builder.HasOne(t => t.LocalityClassDetail)
                .WithMany(t => t.LocalityClassPersonAddresses)
                .HasForeignKey(d => d.LocalityClassId)
                .HasConstraintName("FK__PersonAdd__Local__2739D489");

            builder.HasOne(t => t.Person)
                .WithMany(t => t.PersonAddresses)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonAdd__Perso__208CD6FA");

            builder.HasOne(t => t.ResidentialStatusDetail)
                .WithMany(t => t.ResidentialStatusPersonAddresses)
                .HasForeignKey(d => d.ResidentialStatusId)
                .HasConstraintName("FK__PersonAdd__Resid__282DF8C2");

            builder.HasOne(t => t.ResidentialAreaDetail)
                .WithMany(t => t.ResidentialAreaPersonAddresses)
                .HasForeignKey(d => d.ResidentialAreaId)
                .HasConstraintName("FK__PersonAdd__Resid__29221CFB");

            builder.HasOne(t => t.State)
                .WithMany(t => t.PersonAddresses)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__PersonAdd__State__22751F6C");

            builder.HasOne(t => t.Taluka)
                .WithMany(t => t.PersonAddresses)
                .HasForeignKey(d => d.TalukaId)
                .HasConstraintName("FK__PersonAdd__Taluk__245D67DE");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "PersonAddress";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string PersonId = "PersonId";
            public const string CountryId = "CountryId";
            public const string StateId = "StateId";
            public const string CityId = "CityId";
            public const string OtherCity = "OtherCity";
            public const string TalukaId = "TalukaId";
            public const string OtherTaluka = "OtherTaluka";
            public const string DistrictId = "DistrictId";
            public const string OtherDistrict = "OtherDistrict";
            public const string Village = "Village";
            public const string IsPermanent = "IsPermanent";
            public const string RoadName = "RoadName";
            public const string Line1 = "Line1";
            public const string Line2 = "Line2";
            public const string ZipCode = "ZipCode";
            public const string FromYear = "FromYear";
            public const string ToYear = "ToYear";
            public const string RoomsInHome = "RoomsInHome";
            public const string IsGovtBuildUp = "IsGovtBuildUp";
            public const string HomeStatusId = "HomeStatusId";
            public const string LocalityClassId = "LocalityClassId";
            public const string ResidentialStatusId = "ResidentialStatusId";
            public const string ResidentialAreaId = "ResidentialAreaId";
            public const string CreatedById = "CreatedById";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedById = "UpdatedById";
            public const string UpdatedAt = "UpdatedAt";
            public const string IsActive = "IsActive";
        }
        #endregion
    }
}
