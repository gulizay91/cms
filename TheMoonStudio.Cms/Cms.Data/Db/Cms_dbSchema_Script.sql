USE [master]
GO
/****** Object:  Database [CMS_Dev]    Script Date: 10/13/2019 7:51:27 PM ******/
CREATE DATABASE [CMS_Dev]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CMS_Dev', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CMS_Dev.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CMS_Dev_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CMS_Dev_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CMS_Dev] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMS_Dev].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMS_Dev] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMS_Dev] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMS_Dev] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMS_Dev] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMS_Dev] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMS_Dev] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMS_Dev] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMS_Dev] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMS_Dev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMS_Dev] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMS_Dev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMS_Dev] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMS_Dev] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMS_Dev] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMS_Dev] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMS_Dev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMS_Dev] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMS_Dev] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMS_Dev] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMS_Dev] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMS_Dev] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMS_Dev] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMS_Dev] SET RECOVERY FULL 
GO
ALTER DATABASE [CMS_Dev] SET  MULTI_USER 
GO
ALTER DATABASE [CMS_Dev] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMS_Dev] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMS_Dev] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMS_Dev] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CMS_Dev] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CMS_Dev', N'ON'
GO
ALTER DATABASE [CMS_Dev] SET QUERY_STORE = OFF
GO
USE [CMS_Dev]
GO
/****** Object:  User [dbuser]    Script Date: 10/13/2019 7:51:28 PM ******/
CREATE USER [dbuser] FOR LOGIN [dbuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dbuser]
GO
/****** Object:  Table [dbo].[Boat]    Script Date: 10/13/2019 7:51:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RegisterNumber] [nvarchar](100) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Year] [int] NULL,
	[MotorBrand] [nvarchar](100) NULL,
	[NumberOfEngines] [int] NULL,
	[EnginePower] [int] NULL,
	[Fuel] [nvarchar](100) NULL,
	[Body] [nvarchar](100) NULL,
	[Height] [float] NULL,
	[Width] [float] NULL,
	[Cabin] [int] NULL,
	[NumberOfBed] [int] NULL,
	[CrewCapacity] [int] NULL,
	[GuestCapacity] [int] NULL,
	[Flag] [nvarchar](100) NULL,
	[MarinaId] [int] NULL,
	[IsMotorYacht] [bit] NULL,
	[IsCommercialBoat] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Boat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoatCrew]    Script Date: 10/13/2019 7:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoatCrew](
	[Id] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[BoatId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsFrozen] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoatHistory]    Script Date: 10/13/2019 7:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoatHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoatId] [int] NOT NULL,
	[RegisterNumber] [nvarchar](250) NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Year] [int] NULL,
	[MotorBrand] [nvarchar](500) NULL,
	[NumberOfEngines] [int] NULL,
	[EnginePower] [int] NULL,
	[Fuel] [nvarchar](500) NULL,
	[Body] [nvarchar](500) NULL,
	[Height] [float] NULL,
	[Width] [float] NULL,
	[Cabin] [int] NULL,
	[NumberOfBed] [int] NULL,
	[CrewCapacity] [int] NULL,
	[GuestCapacity] [int] NULL,
	[Flag] [nvarchar](250) NULL,
	[MarinaId] [int] NULL,
	[IsMotorYacht] [bit] NULL,
	[IsCommercialBoat] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_BoatHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Charter]    Script Date: 10/13/2019 7:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[HirerName] [nvarchar](100) NOT NULL,
	[HirerLastName] [nvarchar](150) NOT NULL,
	[HirerPhone] [nvarchar](50) NULL,
	[NumberOfGuest] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Charter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 10/13/2019 7:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Crew]    Script Date: 10/13/2019 7:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crew](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Crew] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ExpenseTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Explanation] [nvarchar](500) NULL,
	[PaidAmount] [float] NOT NULL,
	[RemainingAmount] [float] NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseType]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_ExpenseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fixture]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fixture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[BoatId] [int] NOT NULL,
	[ProductNumber] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Brand] [nvarchar](100) NULL,
	[Total] [int] NOT NULL,
	[Note] [nvarchar](500) NULL,
	[ExpirationDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Fixture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marina]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Marina] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [uniqueidentifier] NOT NULL,
	[CompanyId] [int] NULL,
	[Code] [nvarchar](250) NULL,
	[Key] [nvarchar](500) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [uniqueidentifier] NOT NULL,
	[ApiKey] [nvarchar](250) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Theme] [nvarchar](250) NULL,
	[IsFrozen] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenantHistory]    Script Date: 10/13/2019 7:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [uniqueidentifier] NOT NULL,
	[ApiKey] [nvarchar](250) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Theme] [nvarchar](250) NULL,
	[IsFrozen] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_TenantHistory] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/13/2019 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[IdentityNumber] [bigint] NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Birthday] [datetime] NULL,
	[Avatar] [varbinary](max) NULL,
	[IsFrozen] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 10/13/2019 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [nvarchar](10) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Boat]  WITH CHECK ADD  CONSTRAINT [FK_Boat_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Boat] CHECK CONSTRAINT [FK_Boat_Company]
GO
ALTER TABLE [dbo].[BoatHistory]  WITH CHECK ADD  CONSTRAINT [FK_BoatHistory_Boat] FOREIGN KEY([BoatId])
REFERENCES [dbo].[Boat] ([Id])
GO
ALTER TABLE [dbo].[BoatHistory] CHECK CONSTRAINT [FK_BoatHistory_Boat]
GO
ALTER TABLE [dbo].[Charter]  WITH CHECK ADD  CONSTRAINT [FK_Charter_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Charter] CHECK CONSTRAINT [FK_Charter_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Tenant]
GO
ALTER TABLE [dbo].[Crew]  WITH CHECK ADD  CONSTRAINT [FK_Crew_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Crew] CHECK CONSTRAINT [FK_Crew_Company]
GO
ALTER TABLE [dbo].[Crew]  WITH CHECK ADD  CONSTRAINT [FK_Crew_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Crew] CHECK CONSTRAINT [FK_Crew_User]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Company]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_ExpenseType] FOREIGN KEY([ExpenseTypeId])
REFERENCES [dbo].[ExpenseType] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_ExpenseType]
GO
ALTER TABLE [dbo].[ExpenseType]  WITH CHECK ADD  CONSTRAINT [FK_ExpenseType_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[ExpenseType] CHECK CONSTRAINT [FK_ExpenseType_Company]
GO
ALTER TABLE [dbo].[Fixture]  WITH CHECK ADD  CONSTRAINT [FK_Fixture_Boat] FOREIGN KEY([BoatId])
REFERENCES [dbo].[Boat] ([Id])
GO
ALTER TABLE [dbo].[Fixture] CHECK CONSTRAINT [FK_Fixture_Boat]
GO
ALTER TABLE [dbo].[Fixture]  WITH CHECK ADD  CONSTRAINT [FK_Fixture_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Fixture] CHECK CONSTRAINT [FK_Fixture_Company]
GO
ALTER TABLE [dbo].[Marina]  WITH CHECK ADD  CONSTRAINT [FK_Marina_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Marina] CHECK CONSTRAINT [FK_Marina_Company]
GO
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_Settings_Tenant]
GO
ALTER TABLE [dbo].[TenantHistory]  WITH CHECK ADD  CONSTRAINT [FK_TenantHistory_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[TenantHistory] CHECK CONSTRAINT [FK_TenantHistory_Tenant]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Company]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
ALTER TABLE [dbo].[UserType]  WITH CHECK ADD  CONSTRAINT [FK_UserType_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[UserType] CHECK CONSTRAINT [FK_UserType_Company]
GO
USE [master]
GO
ALTER DATABASE [CMS_Dev] SET  READ_WRITE 
GO
