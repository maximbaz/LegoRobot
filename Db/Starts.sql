USE [LegoRobot.Model.RouteContext]
GO

/****** Object:  Table [dbo].[Starts]    Script Date: 03/25/2012 15:58:58 ******/
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

