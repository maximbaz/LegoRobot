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

