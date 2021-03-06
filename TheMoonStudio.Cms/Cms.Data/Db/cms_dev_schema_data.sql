USE [CMS_Dev]
GO
/****** Object:  Table [dbo].[Boat]    Script Date: 11/16/2019 3:20:29 PM ******/
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
/****** Object:  Table [dbo].[BoatCrew]    Script Date: 11/16/2019 3:20:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoatCrew](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[BoatId] [int] NOT NULL,
	[CrewId] [int] NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
	[IsFrozen] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_BoatCrew] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoatHistory]    Script Date: 11/16/2019 3:20:30 PM ******/
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
/****** Object:  Table [dbo].[Charter]    Script Date: 11/16/2019 3:20:30 PM ******/
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
/****** Object:  Table [dbo].[Company]    Script Date: 11/16/2019 3:20:30 PM ******/
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
/****** Object:  Table [dbo].[Crew]    Script Date: 11/16/2019 3:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crew](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Expense]    Script Date: 11/16/2019 3:20:30 PM ******/
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
/****** Object:  Table [dbo].[ExpenseType]    Script Date: 11/16/2019 3:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](1000) NOT NULL,
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
/****** Object:  Table [dbo].[Fixture]    Script Date: 11/16/2019 3:20:30 PM ******/
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
/****** Object:  Table [dbo].[Marina]    Script Date: 11/16/2019 3:20:30 PM ******/
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
/****** Object:  Table [dbo].[Settings]    Script Date: 11/16/2019 3:20:31 PM ******/
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
/****** Object:  Table [dbo].[Tenant]    Script Date: 11/16/2019 3:20:31 PM ******/
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
/****** Object:  Table [dbo].[TenantHistory]    Script Date: 11/16/2019 3:20:31 PM ******/
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
 CONSTRAINT [PK_TenantHistory_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/16/2019 3:20:31 PM ******/
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
/****** Object:  Table [dbo].[UserRefreshToken]    Script Date: 11/16/2019 3:20:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRefreshToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RefreshToken] [varchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [int] NULL,
 CONSTRAINT [PK_UserRefreshToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 11/16/2019 3:20:31 PM ******/
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
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [TenantId], [Name], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, N'9ebb0810-fe51-44c0-89e8-c23993103fda', N'TestCompany', 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Tenant] ON 

INSERT [dbo].[Tenant] ([Id], [TenantId], [ApiKey], [Name], [Theme], [IsFrozen], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (3, N'10795647-cc06-40f9-8514-395c17bc4339', N'tenant-003-company1', N'Company1', NULL, NULL, 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
INSERT [dbo].[Tenant] ([Id], [TenantId], [ApiKey], [Name], [Theme], [IsFrozen], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (2, N'05ad0514-9451-4914-9aa2-9b706fd3c76c', N'tenant-002-demo', N'TenantDemo', NULL, NULL, 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
INSERT [dbo].[Tenant] ([Id], [TenantId], [ApiKey], [Name], [Theme], [IsFrozen], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, N'9ebb0810-fe51-44c0-89e8-c23993103fda', N'tenant-001-test', N'TenantTest', NULL, NULL, 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tenant] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [CompanyId], [UserTypeId], [IdentityNumber], [Username], [Password], [FirstName], [LastName], [Email], [Birthday], [Avatar], [IsFrozen], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, 1, 1, 11111111111, N'admin', N'123', N'Admin', N'Admin', N'admin@admin', CAST(N'2019-11-15T00:00:00.000' AS DateTime), NULL, NULL, 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRefreshToken] ON 

INSERT [dbo].[UserRefreshToken] ([Id], [UserId], [RefreshToken], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, 1, N'C6686A5EF65931B8C334A3D6FAC93BBEE373C1586D5B0857BBF724F09686DFAE', 1, CAST(N'2019-11-16T09:32:34.073' AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserRefreshToken] OFF
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([Id], [CompanyId], [Code], [Name], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, 1, N'sa', N'Admin', 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
INSERT [dbo].[UserType] ([Id], [CompanyId], [Code], [Name], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (2, 1, N'boss', N'Owner', 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
INSERT [dbo].[UserType] ([Id], [CompanyId], [Code], [Name], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (3, 1, N'captain', N'Captain', 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
INSERT [dbo].[UserType] ([Id], [CompanyId], [Code], [Name], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (4, 1, N'sailor', N'Sailor', 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
INSERT [dbo].[UserType] ([Id], [CompanyId], [Code], [Name], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (5, 1, N'accountant', N'Accountant', 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), -1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserType] OFF
ALTER TABLE [dbo].[Boat]  WITH CHECK ADD  CONSTRAINT [FK_Boat_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Boat] CHECK CONSTRAINT [FK_Boat_Company]
GO
ALTER TABLE [dbo].[Boat]  WITH CHECK ADD  CONSTRAINT [FK_Boat_Marina] FOREIGN KEY([MarinaId])
REFERENCES [dbo].[Marina] ([Id])
GO
ALTER TABLE [dbo].[Boat] CHECK CONSTRAINT [FK_Boat_Marina]
GO
ALTER TABLE [dbo].[BoatCrew]  WITH CHECK ADD  CONSTRAINT [FK_BoatCrew_Boat] FOREIGN KEY([BoatId])
REFERENCES [dbo].[Boat] ([Id])
GO
ALTER TABLE [dbo].[BoatCrew] CHECK CONSTRAINT [FK_BoatCrew_Boat]
GO
ALTER TABLE [dbo].[BoatCrew]  WITH CHECK ADD  CONSTRAINT [FK_BoatCrew_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[BoatCrew] CHECK CONSTRAINT [FK_BoatCrew_Company]
GO
ALTER TABLE [dbo].[BoatCrew]  WITH CHECK ADD  CONSTRAINT [FK_BoatCrew_Crew] FOREIGN KEY([CrewId])
REFERENCES [dbo].[Crew] ([Id])
GO
ALTER TABLE [dbo].[BoatCrew] CHECK CONSTRAINT [FK_BoatCrew_Crew]
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
ALTER TABLE [dbo].[UserRefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_UserRefreshToken_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRefreshToken] CHECK CONSTRAINT [FK_UserRefreshToken_User]
GO
ALTER TABLE [dbo].[UserType]  WITH CHECK ADD  CONSTRAINT [FK_UserType_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[UserType] CHECK CONSTRAINT [FK_UserType_Company]
GO
