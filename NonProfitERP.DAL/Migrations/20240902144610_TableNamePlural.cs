using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace NonProfitERP.DAL.Migrations
{
    public partial class TableNamePlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WebLink = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                schema: "dbo",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Headers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    WebLink = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                schema: "dbo",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK__State__CountryId__412EB0B6",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WebLink = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Program__Departm__70DDC3D8",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ExtraField = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Detail__HeaderId__5812160E",
                        column: x => x.HeaderId,
                        principalSchema: "dbo",
                        principalTable: "Headers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLogValues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionLogId = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PreviousValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Transacti__Trans__3A81B327",
                        column: x => x.TransactionLogId,
                        principalSchema: "dbo",
                        principalTable: "TransactionLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK__City__StateId__45F365D3",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK__District__StateI__4AB81AF0",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubPrograms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WebLink = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK__SubProgra__Progr__7C4F7684",
                        column: x => x.ProgramId,
                        principalSchema: "dbo",
                        principalTable: "Programs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PersonTypeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    BirthLocation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", nullable: false),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HighLightText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Keywords = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    IsWorker = table.Column<bool>(type: "bit", nullable: false),
                    WorkFrequencyId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    JoinedAsId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    ProfilePicturePath = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    HeroPicturePath = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Person__CountryI__60A75C0F",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Person__PersonTy__5CD6CB2B",
                        column: x => x.PersonTypeId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Person__WorkFreq__5EBF139D",
                        column: x => x.WorkFrequencyId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Universit__CityI__18B6AB08",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talukas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talukas", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Taluka__District__4F7CD00D",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ProgramId = table.Column<int>(type: "int", nullable: true),
                    SubProgramId = table.Column<int>(type: "int", nullable: true),
                    HeadId = table.Column<int>(type: "int", nullable: true),
                    CourseName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Course__Departme__08B54D69",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Course__HeadId__0B91BA14",
                        column: x => x.HeadId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Course__ProgramI__09A971A2",
                        column: x => x.ProgramId,
                        principalSchema: "dbo",
                        principalTable: "Programs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Course__SubProgr__0A9D95DB",
                        column: x => x.SubProgramId,
                        principalSchema: "dbo",
                        principalTable: "SubPrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventAttendances",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK__EventAtte__Event__0D44F85C",
                        column: x => x.EventId,
                        principalSchema: "dbo",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__EventAtte__Perso__0C50D423",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAchievements",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    AwardLevelId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    GivenBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Format = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Reason = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonAch__Award__245D67DE",
                        column: x => x.AwardLevelId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAch__Perso__236943A5",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonBatches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonBat__Perso__1DB06A4F",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ContactTypeId = table.Column<int>(type: "int", nullable: true),
                    Detail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonCon__Conta__37703C52",
                        column: x => x.ContactTypeId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonCon__Perso__367C1819",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDepartments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonDep__Depar__6B24EA82",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonDep__Perso__6A30C649",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDisabilities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Detail = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    FromYear = table.Column<int>(type: "int", nullable: true),
                    ToYear = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDisabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonDis__Perso__3C34F16F",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFamilyDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    MobileNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    OtherOrganization = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SchoolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    MonthlyIncome = table.Column<double>(type: "float", nullable: true),
                    RelationId = table.Column<int>(type: "int", nullable: true),
                    OtherRelation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    OtherCourse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    AnyDisability = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonFam__Cours__5AB9788F",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonFam__Organ__58D1301D",
                        column: x => x.OrganizationId,
                        principalSchema: "dbo",
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonFam__Perso__57DD0BE4",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonFam__Relat__59C55456",
                        column: x => x.RelationId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonHealthDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    IQ = table.Column<double>(type: "float", nullable: true),
                    WakeUpTiming = table.Column<double>(type: "float", nullable: true),
                    SleepTiming = table.Column<double>(type: "float", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHealthDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonHea__Perso__5F7E2DAC",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbyFavorites",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HobbyFavoriteId = table.Column<int>(type: "int", nullable: true),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbyFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonHob__Hobby__65370702",
                        column: x => x.HobbyFavoriteId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonHob__Perso__6442E2C9",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    OtherLanguage = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsMotherTongue = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonLan__Langu__6AEFE058",
                        column: x => x.LanguageId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonLan__Perso__69FBBC1F",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPrivateInformation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    AadharCardNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    PANNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsOwnBicycle = table.Column<bool>(type: "bit", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    OtherReligion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CasteId = table.Column<int>(type: "int", nullable: true),
                    OtherCaste = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    OtherCategory = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ParentalStatusId = table.Column<int>(type: "int", nullable: true),
                    OtherParentalStatus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    DateOfExpiry = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPrivateInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonPri__Caste__72910220",
                        column: x => x.CasteId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonPri__Categ__73852659",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonPri__Paren__74794A92",
                        column: x => x.ParentalStatusId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonPri__Perso__70A8B9AE",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonPri__Relig__719CDDE7",
                        column: x => x.ReligionId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonPrograms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonPro__Perso__75A278F5",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonPro__Progr__76969D2E",
                        column: x => x.ProgramId,
                        principalSchema: "dbo",
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSocialMediaAccount",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: true),
                    OtherAccountType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Link = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TypeOfUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSocialMediaAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonSoc__Accou__7A3223E8",
                        column: x => x.AccountTypeId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonSoc__Perso__793DFFAF",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonSoc__TypeO__7B264821",
                        column: x => x.TypeOfUserId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSubPrograms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SubProgramId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSubPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonSub__Perso__02084FDA",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonSub__SubPr__02FC7413",
                        column: x => x.SubProgramId,
                        principalSchema: "dbo",
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonWorkExperiences",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    OtherOrganization = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    WorkTypeId = table.Column<int>(type: "int", nullable: true),
                    OtherWorkType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    OtherDepartment = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    OtherDesignation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FromYear = table.Column<int>(type: "int", nullable: true),
                    ToYear = table.Column<int>(type: "int", nullable: true),
                    Specialization = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsFreeLance = table.Column<bool>(type: "bit", nullable: true),
                    IsFullTime = table.Column<bool>(type: "bit", nullable: true),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonWorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonWor__Depar__02C769E9",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonWor__Desig__03BB8E22",
                        column: x => x.DesignationId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonWor__Organ__00DF2177",
                        column: x => x.OrganizationId,
                        principalSchema: "dbo",
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonWor__Perso__7FEAFD3E",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonWor__WorkT__01D345B0",
                        column: x => x.WorkTypeId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TicketCount = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Ticket__EventId__1209AD79",
                        column: x => x.EventId,
                        principalSchema: "dbo",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Ticket__PersonId__12FDD1B2",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    OtherCity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TalukaId = table.Column<int>(type: "int", nullable: true),
                    OtherTaluka = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    OtherDistrict = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Village = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsPermanent = table.Column<bool>(type: "bit", nullable: false),
                    RoadName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Line1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Line2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FromYear = table.Column<int>(type: "int", nullable: true),
                    ToYear = table.Column<int>(type: "int", nullable: true),
                    RoomsInHome = table.Column<int>(type: "int", nullable: true),
                    IsGovtBuildUp = table.Column<bool>(type: "bit", nullable: true),
                    HomeStatusId = table.Column<int>(type: "int", nullable: true),
                    LocalityClassId = table.Column<int>(type: "int", nullable: true),
                    ResidentialStatusId = table.Column<int>(type: "int", nullable: true),
                    ResidentialAreaId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonAdd__CityI__2BFE89A6",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__Count__2A164134",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__Distr__2DE6D218",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "Districts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__HomeS__2EDAF651",
                        column: x => x.HomeStatusId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__Local__2FCF1A8A",
                        column: x => x.LocalityClassId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__Perso__29221CFB",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonAdd__Resid__30C33EC3",
                        column: x => x.ResidentialStatusId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__Resid__31B762FC",
                        column: x => x.ResidentialAreaId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__State__2B0A656D",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonAdd__Taluk__2CF2ADDF",
                        column: x => x.TalukaId,
                        principalSchema: "dbo",
                        principalTable: "Talukas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ContactPersonName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ContactPersonDesignation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ContactPersonContactNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    TalukaId = table.Column<int>(type: "int", nullable: true),
                    OtherTaluka = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    OtherDistrict = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    PhoneNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WebLink = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SchoolTypeId = table.Column<int>(type: "int", nullable: true),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK__School__District__41EDCAC5",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "Districts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__School__SchoolTy__43D61337",
                        column: x => x.SchoolTypeId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__School__StateId__42E1EEFE",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__School__TalukaId__40F9A68C",
                        column: x => x.TalukaId,
                        principalSchema: "dbo",
                        principalTable: "Talukas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Year = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LongText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Batch__CourseId__17F790F9",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseHeads",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CourseHea__Cours__123EB7A3",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CourseHea__Perso__114A936A",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonEducations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: true),
                    OtherSchool = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FromStdId = table.Column<int>(type: "int", nullable: true),
                    ToStdId = table.Column<int>(type: "int", nullable: true),
                    MediumId = table.Column<int>(type: "int", nullable: true),
                    OtherMedium = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FromYear = table.Column<int>(type: "int", nullable: false),
                    ToYear = table.Column<int>(type: "int", nullable: true),
                    UniversityBoardId = table.Column<int>(type: "int", nullable: true),
                    OtherUniversityBoard = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DegreeId = table.Column<int>(type: "int", nullable: true),
                    OtherDegree = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    OtherCourse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Specialization = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PersonEdu__Cours__725BF7F6",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonEdu__Degre__7167D3BD",
                        column: x => x.DegreeId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonEdu__FromS__6D9742D9",
                        column: x => x.FromStdId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonEdu__Mediu__6F7F8B4B",
                        column: x => x.MediumId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonEdu__Perso__6BAEFA67",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonEdu__Schoo__6CA31EA0",
                        column: x => x.SchoolId,
                        principalSchema: "dbo",
                        principalTable: "Schools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonEdu__ToStd__6E8B6712",
                        column: x => x.ToStdId,
                        principalSchema: "dbo",
                        principalTable: "Details",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonEdu__Unive__7073AF84",
                        column: x => x.UniversityBoardId,
                        principalSchema: "dbo",
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_CourseId",
                schema: "dbo",
                table: "Batches",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                schema: "dbo",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseHeads_CourseId",
                schema: "dbo",
                table: "CourseHeads",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseHeads_PersonId",
                schema: "dbo",
                table: "CourseHeads",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                schema: "dbo",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HeadId",
                schema: "dbo",
                table: "Courses",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProgramId",
                schema: "dbo",
                table: "Courses",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubProgramId",
                schema: "dbo",
                table: "Courses",
                column: "SubProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_HeaderId",
                schema: "dbo",
                table: "Details",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_StateId",
                schema: "dbo",
                table: "Districts",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendances_EventId",
                schema: "dbo",
                table: "EventAttendances",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendances_PersonId",
                schema: "dbo",
                table: "EventAttendances",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CountryId",
                schema: "dbo",
                table: "People",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonTypeId",
                schema: "dbo",
                table: "People",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_People_WorkFrequencyId",
                schema: "dbo",
                table: "People",
                column: "WorkFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAchievements_AwardLevelId",
                schema: "dbo",
                table: "PersonAchievements",
                column: "AwardLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAchievements_PersonId",
                schema: "dbo",
                table: "PersonAchievements",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_CityId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_CountryId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_DistrictId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_HomeStatusId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "HomeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_LocalityClassId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "LocalityClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_PersonId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_ResidentialAreaId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "ResidentialAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_ResidentialStatusId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "ResidentialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_StateId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_TalukaId",
                schema: "dbo",
                table: "PersonAddresses",
                column: "TalukaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonBatches_PersonId",
                schema: "dbo",
                table: "PersonBatches",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_ContactTypeId",
                schema: "dbo",
                table: "PersonContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_PersonId",
                schema: "dbo",
                table: "PersonContacts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDepartments_DepartmentId",
                schema: "dbo",
                table: "PersonDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDepartments_PersonId",
                schema: "dbo",
                table: "PersonDepartments",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDisabilities_PersonId",
                schema: "dbo",
                table: "PersonDisabilities",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_CourseId",
                schema: "dbo",
                table: "PersonEducations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_DegreeId",
                schema: "dbo",
                table: "PersonEducations",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_FromStdId",
                schema: "dbo",
                table: "PersonEducations",
                column: "FromStdId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_MediumId",
                schema: "dbo",
                table: "PersonEducations",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_PersonId",
                schema: "dbo",
                table: "PersonEducations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_SchoolId",
                schema: "dbo",
                table: "PersonEducations",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_ToStdId",
                schema: "dbo",
                table: "PersonEducations",
                column: "ToStdId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_UniversityBoardId",
                schema: "dbo",
                table: "PersonEducations",
                column: "UniversityBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamilyDetails_CourseId",
                schema: "dbo",
                table: "PersonFamilyDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamilyDetails_OrganizationId",
                schema: "dbo",
                table: "PersonFamilyDetails",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamilyDetails_PersonId",
                schema: "dbo",
                table: "PersonFamilyDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamilyDetails_RelationId",
                schema: "dbo",
                table: "PersonFamilyDetails",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHealthDetails_PersonId",
                schema: "dbo",
                table: "PersonHealthDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbyFavorites_HobbyFavoriteId",
                schema: "dbo",
                table: "PersonHobbyFavorites",
                column: "HobbyFavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbyFavorites_PersonId",
                schema: "dbo",
                table: "PersonHobbyFavorites",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_LanguageId",
                schema: "dbo",
                table: "PersonLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_PersonId",
                schema: "dbo",
                table: "PersonLanguages",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrivateInformation_CasteId",
                schema: "dbo",
                table: "PersonPrivateInformation",
                column: "CasteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrivateInformation_CategoryId",
                schema: "dbo",
                table: "PersonPrivateInformation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrivateInformation_ParentalStatusId",
                schema: "dbo",
                table: "PersonPrivateInformation",
                column: "ParentalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrivateInformation_PersonId",
                schema: "dbo",
                table: "PersonPrivateInformation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrivateInformation_ReligionId",
                schema: "dbo",
                table: "PersonPrivateInformation",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrograms_PersonId",
                schema: "dbo",
                table: "PersonPrograms",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPrograms_ProgramId",
                schema: "dbo",
                table: "PersonPrograms",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialMediaAccount_AccountTypeId",
                schema: "dbo",
                table: "PersonSocialMediaAccount",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialMediaAccount_PersonId",
                schema: "dbo",
                table: "PersonSocialMediaAccount",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialMediaAccount_TypeOfUserId",
                schema: "dbo",
                table: "PersonSocialMediaAccount",
                column: "TypeOfUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubPrograms_PersonId",
                schema: "dbo",
                table: "PersonSubPrograms",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubPrograms_SubProgramId",
                schema: "dbo",
                table: "PersonSubPrograms",
                column: "SubProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_DepartmentId",
                schema: "dbo",
                table: "PersonWorkExperiences",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_DesignationId",
                schema: "dbo",
                table: "PersonWorkExperiences",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_OrganizationId",
                schema: "dbo",
                table: "PersonWorkExperiences",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_PersonId",
                schema: "dbo",
                table: "PersonWorkExperiences",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_WorkTypeId",
                schema: "dbo",
                table: "PersonWorkExperiences",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_DepartmentId",
                schema: "dbo",
                table: "Programs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_DistrictId",
                schema: "dbo",
                table: "Schools",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SchoolTypeId",
                schema: "dbo",
                table: "Schools",
                column: "SchoolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_StateId",
                schema: "dbo",
                table: "Schools",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_TalukaId",
                schema: "dbo",
                table: "Schools",
                column: "TalukaId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                schema: "dbo",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPrograms_ProgramId",
                schema: "dbo",
                table: "SubPrograms",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Talukas_DistrictId",
                schema: "dbo",
                table: "Talukas",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                schema: "dbo",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonId",
                schema: "dbo",
                table: "Tickets",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLogValues_TransactionLogId",
                schema: "dbo",
                table: "TransactionLogValues",
                column: "TransactionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CityId",
                schema: "dbo",
                table: "Universities",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Batches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CourseHeads",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DeviceCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EventAttendances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersistedGrants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonAchievements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonAddresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonBatches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonContacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonDepartments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonDisabilities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonEducations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonFamilyDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonHealthDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonHobbyFavorites",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonLanguages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonPrivateInformation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonPrograms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonSocialMediaAccount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonSubPrograms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonWorkExperiences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TransactionLogValues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Schools",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Universities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TransactionLogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "People",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubPrograms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Talukas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Programs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Districts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Headers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "States",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "dbo");
        }
    }
}
