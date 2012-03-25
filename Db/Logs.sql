USE [LegoRobot.Model.RouteContext]
GO

/****** Object:  Table [dbo].[Logs]    Script Date: 03/25/2012 15:58:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs](
	[Id] [uniqueidentifier] NOT NULL,
	[RouteId] [uniqueidentifier] NOT NULL,
	[Start] [datetime] NOT NULL,
	[Suceed] [bit] NOT NULL,
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
