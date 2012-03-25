USE [LegoRobot.Model.RouteContext]
GO

/****** Object:  Table [dbo].[RouteErrors]    Script Date: 03/25/2012 15:58:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RouteErrors](
	[RouteId] [uniqueidentifier] NOT NULL,
	[PointId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RouteErrors] PRIMARY KEY CLUSTERED 
(
	[RouteId] ASC,
	[PointId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RouteErrors]  WITH CHECK ADD  CONSTRAINT [FK_RouteErrors_Points_PointId] FOREIGN KEY([PointId])
REFERENCES [dbo].[Points] ([Id])
GO

ALTER TABLE [dbo].[RouteErrors] CHECK CONSTRAINT [FK_RouteErrors_Points_PointId]
GO

ALTER TABLE [dbo].[RouteErrors]  WITH CHECK ADD  CONSTRAINT [FK_RouteErrors_Routes_RouteId] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RouteErrors] CHECK CONSTRAINT [FK_RouteErrors_Routes_RouteId]
GO

