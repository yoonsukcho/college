USE [master]
GO
/****** Object:  Database [ITSD]    Script Date: 11/4/2016 12:58:19 PM ******/
CREATE DATABASE [ITSD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITSD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ITSD.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITSD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ITSD_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ITSD] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITSD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITSD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITSD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITSD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITSD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITSD] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITSD] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ITSD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITSD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITSD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITSD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITSD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITSD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITSD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITSD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITSD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ITSD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITSD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITSD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITSD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITSD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITSD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ITSD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITSD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ITSD] SET  MULTI_USER 
GO
ALTER DATABASE [ITSD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ITSD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITSD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITSD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ITSD] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ITSD]
GO
/****** Object:  Table [dbo].[Change]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Change](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[status] [varchar](30) NOT NULL,
	[reqeustMode] [varchar](30) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](8000) NULL,
	[requester] [int] NOT NULL,
	[agent] [int] NOT NULL,
	[impact] [varchar](10) NOT NULL,
	[urgency] [varchar](30) NOT NULL,
	[priority] [varchar](10) NOT NULL,
	[category] [varchar](30) NOT NULL,
	[changeRisk] [int] NOT NULL,
	[reason] [varchar](8000) NULL,
	[implications] [varchar](255) NOT NULL,
	[rolloutPlan] [varchar](255) NOT NULL,
	[backoutPlan] [varchar](255) NOT NULL,
	[releaseInfo] [varchar](255) NOT NULL,
	[risk] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](30) NOT NULL,
	[middleName] [varchar](30) NULL,
	[lastName] [varchar](30) NOT NULL,
	[employeeType] [varchar](10) NOT NULL,
	[positionId] [int] NOT NULL,
	[departmentId] [int] NOT NULL,
	[locationId] [int] NOT NULL,
	[workEmail] [varchar](50) NOT NULL,
	[workPhone] [varchar](30) NOT NULL,
	[phoneExtension] [varchar](10) NOT NULL,
	[note] [varchar](8000) NULL,
	[picture] [varchar](255) NOT NULL,
	[servicetier] [varchar](30) NOT NULL,
	[servicedeskPosition] [varchar](30) NOT NULL,
	[privateEmail] [varchar](50) NOT NULL,
	[privatePhone] [varchar](30) NOT NULL,
	[businessImpact] [varchar](10) NOT NULL,
	[VIP] [bit] NOT NULL,
	[serviceRequestApprover] [bit] NOT NULL,
	[POApprover] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeServiceTeam]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeServiceTeam](
	[employeeId] [int] NOT NULL,
	[serviceteamId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC,
	[serviceteamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incident]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Incident](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[status] [varchar](30) NOT NULL,
	[reqeustMode] [varchar](30) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](8000) NULL,
	[requester] [int] NOT NULL,
	[agent] [int] NOT NULL,
	[impact] [varchar](10) NOT NULL,
	[urgency] [varchar](30) NOT NULL,
	[priority] [varchar](10) NOT NULL,
	[nonErrorRecorId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Position]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Problem]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Problem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[status] [varchar](30) NOT NULL,
	[reqeustMode] [varchar](30) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](8000) NULL,
	[requester] [int] NOT NULL,
	[agent] [int] NOT NULL,
	[impact] [varchar](10) NOT NULL,
	[urgency] [varchar](30) NOT NULL,
	[priority] [varchar](10) NOT NULL,
	[rootCause] [varchar](255) NOT NULL,
	[symtoms] [varchar](255) NOT NULL,
	[permSolutionTitle] [varchar](255) NOT NULL,
	[permSolutionDescription] [varchar](8000) NULL,
	[workSolutionTitle] [varchar](255) NOT NULL,
	[workSolutionDescription] [varchar](8000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceRequest]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceRequest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[status] [varchar](30) NOT NULL,
	[reqeustMode] [varchar](30) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](8000) NULL,
	[requester] [int] NOT NULL,
	[agent] [int] NOT NULL,
	[impact] [varchar](10) NOT NULL,
	[urgency] [varchar](30) NOT NULL,
	[priority] [varchar](10) NOT NULL,
	[serviceItemId] [int] NOT NULL,
	[serviceAgreementId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Serviceteam]    Script Date: 11/4/2016 12:58:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Serviceteam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Change]  WITH CHECK ADD  CONSTRAINT [FKChange718544] FOREIGN KEY([requester])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Change] CHECK CONSTRAINT [FKChange718544]
GO
ALTER TABLE [dbo].[Change]  WITH CHECK ADD  CONSTRAINT [FKChange902496] FOREIGN KEY([agent])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Change] CHECK CONSTRAINT [FKChange902496]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FKEmployee21894] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FKEmployee21894]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FKEmployee362805] FOREIGN KEY([positionId])
REFERENCES [dbo].[Position] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FKEmployee362805]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FKEmployee674756] FOREIGN KEY([locationId])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FKEmployee674756]
GO
ALTER TABLE [dbo].[EmployeeServiceTeam]  WITH CHECK ADD  CONSTRAINT [FKEmployeeSe184951] FOREIGN KEY([serviceteamId])
REFERENCES [dbo].[Serviceteam] ([id])
GO
ALTER TABLE [dbo].[EmployeeServiceTeam] CHECK CONSTRAINT [FKEmployeeSe184951]
GO
ALTER TABLE [dbo].[EmployeeServiceTeam]  WITH CHECK ADD  CONSTRAINT [FKEmployeeSe351122] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[EmployeeServiceTeam] CHECK CONSTRAINT [FKEmployeeSe351122]
GO
ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FKIncident497214] FOREIGN KEY([agent])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FKIncident497214]
GO
ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FKIncident681166] FOREIGN KEY([requester])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FKIncident681166]
GO
ALTER TABLE [dbo].[Problem]  WITH CHECK ADD  CONSTRAINT [FKProblem806199] FOREIGN KEY([requester])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Problem] CHECK CONSTRAINT [FKProblem806199]
GO
ALTER TABLE [dbo].[Problem]  WITH CHECK ADD  CONSTRAINT [FKProblem990151] FOREIGN KEY([agent])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Problem] CHECK CONSTRAINT [FKProblem990151]
GO
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FKServiceReq240102] FOREIGN KEY([requester])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FKServiceReq240102]
GO
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FKServiceReq943849] FOREIGN KEY([agent])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FKServiceReq943849]
GO
USE [master]
GO
ALTER DATABASE [ITSD] SET  READ_WRITE 
GO
