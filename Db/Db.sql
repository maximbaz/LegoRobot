USE [master]
GO

/****** Object:  Database [LegoRobot]    Script Date: 04/24/2012 15:09:57 ******/
CREATE DATABASE [LegoRobot] ON  PRIMARY
( NAME = N'LegoRobot', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\LegoRobot.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON
( NAME = N'LegoRobot_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\LegoRobot_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [LegoRobot] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LegoRobot].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LegoRobot] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [LegoRobot] SET ANSI_NULLS OFF
GO

ALTER DATABASE [LegoRobot] SET ANSI_PADDING OFF
GO

ALTER DATABASE [LegoRobot] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [LegoRobot] SET ARITHABORT OFF
GO

ALTER DATABASE [LegoRobot] SET AUTO_CLOSE ON
GO

ALTER DATABASE [LegoRobot] SET AUTO_CREATE_STATISTICS ON
GO

ALTER DATABASE [LegoRobot] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [LegoRobot] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [LegoRobot] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [LegoRobot] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [LegoRobot] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [LegoRobot] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [LegoRobot] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [LegoRobot] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [LegoRobot] SET  ENABLE_BROKER
GO

ALTER DATABASE [LegoRobot] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [LegoRobot] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [LegoRobot] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [LegoRobot] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [LegoRobot] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [LegoRobot] SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE [LegoRobot] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [LegoRobot] SET  READ_WRITE
GO

ALTER DATABASE [LegoRobot] SET RECOVERY SIMPLE
GO

ALTER DATABASE [LegoRobot] SET  MULTI_USER
GO

ALTER DATABASE [LegoRobot] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [LegoRobot] SET DB_CHAINING OFF
GO

/**********************************************/

USE [LegoRobot]
GO

/****** Object:  Table [dbo].[Points]    Script Date: 04/24/2012 15:10:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Points](
    [Id] [uniqueidentifier] NOT NULL,
    [X] [float] NOT NULL,
    [Y] [float] NOT NULL,
 CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Points] ADD  DEFAULT (newid()) FOR [Id]
GO

/**********************************************/

USE [LegoRobot]
GO

/****** Object:  Table [dbo].[Starts]    Script Date: 04/24/2012 15:11:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Starts](
    [Id] [uniqueidentifier] NOT NULL,
    [PositionId] [uniqueidentifier] NOT NULL,
    [OffsetId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Starts] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Starts]  WITH CHECK ADD  CONSTRAINT [FK_Starts_Points_OffsetId] FOREIGN KEY([OffsetId])
REFERENCES [dbo].[Points] ([Id])
GO

ALTER TABLE [dbo].[Starts] CHECK CONSTRAINT [FK_Starts_Points_OffsetId]
GO

ALTER TABLE [dbo].[Starts]  WITH CHECK ADD  CONSTRAINT [FK_Starts_Points_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Points] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Starts] CHECK CONSTRAINT [FK_Starts_Points_PositionId]
GO

ALTER TABLE [dbo].[Starts] ADD  DEFAULT (newid()) FOR [Id]
GO

/**********************************************/

USE [LegoRobot]
GO

/****** Object:  Table [dbo].[Routes]    Script Date: 04/24/2012 15:11:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Routes](
    [Id] [uniqueidentifier] NOT NULL,
    [StartId] [uniqueidentifier] NOT NULL,
    [Scale] [float] NOT NULL,
 CONSTRAINT [PK_Routes] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Routes]  WITH CHECK ADD  CONSTRAINT [FK_Routes_Starts_StartId] FOREIGN KEY([StartId])
REFERENCES [dbo].[Starts] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Routes] CHECK CONSTRAINT [FK_Routes_Starts_StartId]
GO

ALTER TABLE [dbo].[Routes] ADD  DEFAULT (newid()) FOR [Id]
GO

/**********************************************/

USE [LegoRobot]
GO

/****** Object:  Table [dbo].[Logs]    Script Date: 04/24/2012 15:10:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs](
    [Id] [uniqueidentifier] NOT NULL,
    [RouteId] [uniqueidentifier] NOT NULL,
    [Finish] [datetime2] NOT NULL,
    [Succeed] [bit] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Routes_RouteId] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Routes_RouteId]
GO

ALTER TABLE [dbo].[Logs] ADD  DEFAULT (newid()) FOR [Id]
GO

/**********************************************/

USE [LegoRobot]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 04/24/2012 15:10:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors](
    [Id] [uniqueidentifier] NOT NULL,
    [StepId] [uniqueidentifier] NOT NULL,
    [Time] [datetime2] NOT NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Errors]  WITH CHECK ADD  CONSTRAINT [FK_Errors_Steps_StepId] FOREIGN KEY([StepId])
REFERENCES [dbo].[Steps] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Errors] CHECK CONSTRAINT [FK_Errors_Steps_StepId]
GO

ALTER TABLE [dbo].[Errors] ADD  DEFAULT (newid()) FOR [Id]
GO

/**********************************************/

USE [LegoRobot]
GO

/****** Object:  Table [dbo].[Steps]    Script Date: 04/24/2012 15:11:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Steps](
    [Id] [uniqueidentifier] NOT NULL,
    [PointId] [uniqueidentifier] NOT NULL,
    [RouteId] [uniqueidentifier] NOT NULL,
    [Order] [int] NOT NULL,
 CONSTRAINT [PK_Steps] PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Steps_Points_PointId] FOREIGN KEY([PointId])
REFERENCES [dbo].[Points] ([Id])
GO

ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Steps_Points_PointId]
GO

ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Steps_Routes_RouteId] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Steps_Routes_RouteId]
GO

ALTER TABLE [dbo].[Steps] ADD  DEFAULT (newid()) FOR [Id]
GO

/**********************************************/
