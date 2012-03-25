USE [master]
GO

/****** Object:  Database [LegoRobot.Model.RouteContext]    Script Date: 03/25/2012 15:58:06 ******/
CREATE DATABASE [LegoRobot.Model.RouteContext] ON  PRIMARY 
( NAME = N'LegoRobot.Model.RouteContext', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\LegoRobot.Model.RouteContext.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LegoRobot.Model.RouteContext_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\LegoRobot.Model.RouteContext_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LegoRobot.Model.RouteContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET ARITHABORT OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET  ENABLE_BROKER 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET  READ_WRITE 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET  MULTI_USER 
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LegoRobot.Model.RouteContext] SET DB_CHAINING OFF 
GO

