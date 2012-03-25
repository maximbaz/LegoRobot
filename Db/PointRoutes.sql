USE [LegoRobot.Model.RouteContext]
GO

/****** Object:  Table [dbo].[PointRoutes]    Script Date: 03/25/2012 15:58:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PointRoutes](
	[PointId] [uniqueidentifier] NOT NULL,
	[RouteId] [uniqueidentifier] NOT NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_PointRoutes] PRIMARY KEY CLUSTERED 
(
	[PointId] ASC,
	[RouteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PointRoutes]  WITH CHECK ADD  CONSTRAINT [FK_PointRoutes_Points_PointId] FOREIGN KEY([PointId])
REFERENCES [dbo].[Points] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PointRoutes] CHECK CONSTRAINT [FK_PointRoutes_Points_PointId]
GO

ALTER TABLE [dbo].[PointRoutes]  WITH CHECK ADD  CONSTRAINT [FK_PointRoutes_Routes_RouteId] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
GO

ALTER TABLE [dbo].[PointRoutes] CHECK CONSTRAINT [FK_PointRoutes_Routes_RouteId]
GO

