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

