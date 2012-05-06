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
	[Time] [datetime] NOT NULL,
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

