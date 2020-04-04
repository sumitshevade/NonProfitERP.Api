USE PublicData
GO

CREATE TABLE Country
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE [State]
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT REFERENCES Country(Id),
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE City
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	StateId INT REFERENCES [State](Id),
	[Name] VARCHAR(50) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Header
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Department
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	StartedAt DATE NULL,
	LongText VARCHAR(500) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Details
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HeaderId INT REFERENCES Header(Id),
	[Value] VARCHAR(100) NOT NULL,
	ExtraField VARCHAR(250) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Person
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonTypeId INT REFERENCES Details(Id) NOT NULL,	-- it was regular, etc, now it is Yuvak or wardhak etc
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NULL,
	LastName VARCHAR(50) NOT NULL,
	BirthDate DATE NULL,
	BirthLocation VARCHAR(50) NULL,
	LongText VARCHAR(500) NULL,
	Keywords VARCHAR(250) NULL,
	IsWorker BIT NOT NULL DEFAULT 0,	-- is he / she working, so that we can assign him work
	WorkFrequency INT REFERENCES Details(Id) NOT NULL,	-- it will be daily, periodic, rare, etc
	JoiningDate DATE NULL,
	JoinedAsId INT REFERENCES Details(Id) NULL,
	CountryId INT REFERENCES Country(Id) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE DepartmentHead
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	DepartmentId INT REFERENCES Department(Id) NOT NULL,
	FromYear INT NOT NULL,
	ToYear INT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Organization
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(250) NULL,
	PanNo VARCHAR(15) NULL,
	IsNasscomRegistered BIT NOT NULL DEFAULT 0,
	LongText VARCHAR(500) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Division
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DepartmentId INT REFERENCES Department(Id) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(250) NOT NULL,
	StartDate DATE NOT NULL,
	LongText VARCHAR(500) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE DivisionHead
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	DivisionId INT REFERENCES Division(Id) NOT NULL,
	FromYear INT NOT NULL,
	ToYear INT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonPrivateInformation
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	PersonId INT REFERENCES Person(Id) NOT NULL,
	MaritalStatus BIT NOT NULL DEFAULT 0,
	AadharCardNo VARCHAR(15) NULL,
	IsOwnBicycle BIT NOT NULL DEFAULT 0,
	ReligionId INT REFERENCES Details(Id) NULL,
	CasteId INT REFERENCES Details(Id) NULL,
	ParentalStatusId INT REFERENCES Details(Id) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonAchievement
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NULL,
	Title VARCHAR(50) NOT NULL,
	GivenBy VARCHAR(100) NULL,
	[Format] VARCHAR(50) NULL,
	Reason VARCHAR(50) NULL,
	ReceivedDate DATE NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonAddress
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	CountryId INT REFERENCES Country(Id) NULL,
	StateId INT REFERENCES [State](Id) NULL,
	CityId INT REFERENCES City(Id) NULL,
	IsPermanent BIT NOT NULL,
	RoadName VARCHAR(25) NULL,
	Line1 VARCHAR(100) NULL,
	Line2 VARCHAR(100) NULL,
	ZipCode VARCHAR(10) NULL,
	FromYear INT NULL,
	ToYear INT NULL,
	RoomsInHome INT NULL,
	IsGovtBuildUp BIT NOT NULL DEFAULT 0,
	HomeStatusId INT REFERENCES Details(Id) NULL,
	LocalityClass INT REFERENCES Details(Id) NULL,
	ResidentialStatus INT REFERENCES Details(Id) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonContact
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	ContactType INT REFERENCES Details(Id) NULL,
	Detail VARCHAR(100),
	IsDefault BIT NOT NULL DEFAULT 0, 
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonDisability
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	Problem VARCHAR(50) NOT NULL,
	Detail VARCHAR(250) NULL,
	FromYear INT NULL,
	ToYear INT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonEducation
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	SchoolId INT REFERENCES Details(Id) NULL,
	FromStdId INT REFERENCES Details(Id) NULL,
	ToStdId INT REFERENCES Details(Id) NULL,
	FromYear INT NOT NULL,
	ToYear INT NULL,
	UniversityBoardId INT REFERENCES Details(Id) NULL,
	DegreeId INT REFERENCES Details(Id) NULL,
	CourseId INT REFERENCES Details(Id) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonFamilyDetails
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NULL,
	LastName VARCHAR(50) NOT NULL,
	BirthDate DATE NULL,
	MobileNo VARCHAR(15) NULL,
	Email VARCHAR(50) NULL,
	CompanyName VARCHAR(50) NULL,
	SchoolName VARCHAR(50) NULL,
	MonthlyIncome FLOAT NULL,
	PersonId INT REFERENCES Person(Id) NULL,
	RelationId INT REFERENCES Details(Id) NULL,
	CourseId INT REFERENCES Details(Id) NULL,
	AnyDisability VARCHAR(100) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonHealthDetails
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	Height FLOAT NULL,
	[Weight] FLOAT NULL,
	IQ FLOAT NULL,
	WakeUpTiming FLOAT NULL,
	SleepTiming FLOAT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonHobbyFavorite
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	HobbyFavoriteId INT REFERENCES Details(Id) NULL,
	LongText VARCHAR(500) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonLanguage
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	LanguageId INT REFERENCES Details(Id) NOT NULL,
	IsMotherTongue BIT NOT NULL DEFAULT 0,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonSocialMediaAccount
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	AccountTypeId INT REFERENCES Details(Id) NOT NULL,
	Link VARCHAR(50) NULL,
	TypeOfUserId INT REFERENCES Details(Id) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE PersonWorkExperience
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	IndustryId INT REFERENCES Details(Id) NOT NULL,
	WorkTypeId INT REFERENCES Details(Id) NULL,
	CompanyName VARCHAR(50) NULL,
	ActualWork VARCHAR(50) NULL,
	FromYear INT NULL,
	ToYear INT NULL,
	LongText VARCHAR(500) NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE University
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CityId INT REFERENCES City(Id) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Program
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE Ticket
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

CREATE TABLE ProgramAttendance
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PersonId INT REFERENCES Person(Id) NOT NULL,
	ProgramId INT REFERENCES Program(Id) NOT NULL,
	CreatedById INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	UpdatedById INT NULL,
	UpdatedAt DATETIME NULL,
	DeletedById INT NULL,
	DeletedAt DATETIME NULL
)
GO

--CREATE TABLE School
--(
--	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	[Name] VARCHAR(50) NOT NULL,
--	[Address] VARCHAR(100) NULL,
--	CreatedById INT NOT NULL,
--	CreatedAt DATETIME NOT NULL,
--	UpdatedById INT NULL,
--	UpdatedAt DATETIME NULL,
--	DeletedById INT NULL,
--	DeletedAt DATETIME NULL
--)
--GO

--CREATE TABLE Industry
--(
--	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	[Name] VARCHAR(50) NOT NULL,
--	LongText VARCHAR(500) NULL,
--	CreatedById INT NOT NULL,
--	CreatedAt DATETIME NOT NULL,
--	UpdatedById INT NULL,
--	UpdatedAt DATETIME NULL,
--	DeletedById INT NULL,
--	DeletedAt DATETIME NULL
--)
--GO

/*
USE PublicData
GO

DROP TABLE ProgramAttendance;
DROP TABLE Ticket;
DROP TABLE Program;
DROP TABLE University;
DROP TABLE PersonWorkExperience;
DROP TABLE PersonSocialMediaAccount;
DROP TABLE PersonLanguage;
DROP TABLE PersonHobbyFavorite;
DROP TABLE PersonHealthDetails;
DROP TABLE PersonFamilyDetails;
DROP TABLE PersonEducation;
DROP TABLE PersonDisability;
DROP TABLE PersonContact;
DROP TABLE PersonAddress;
DROP TABLE PersonAchievement;
DROP TABLE PersonPrivateInformation;
DROP TABLE DivisionHead;
DROP TABLE Division;
DROP TABLE Organization;
DROP TABLE DepartmentHead;
DROP TABLE Person;
DROP TABLE Details;
DROP TABLE Department;
DROP TABLE Header;
DROP TABLE City;
DROP TABLE State;
DROP TABLE Country;
*/

--DROP TABLE School;
--DROP TABLE Industry;

/*

DROP TABLE [AspNetUserTokens]
DROP TABLE [AspNetUsers]
DROP TABLE [AspNetUserRoles]
DROP TABLE[AspNetUserLogins]
DROP TABLE [AspNetUserClaims]
DROP TABLE [AspNetRoles]
DROP TABLE [AspNetRoleClaims]


CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
*/