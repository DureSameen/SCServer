CREATE TABLE [dbo].[Privilege](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](300) NULL,
	[Enabled] [bit] NOT NULL,
	[FeatureId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Privilege] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Privilege]  WITH CHECK ADD  CONSTRAINT [FK_Privilege_Feature] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Feature] ([Id])
GO

ALTER TABLE [dbo].[Privilege] CHECK CONSTRAINT [FK_Privilege_Feature]
GO
ALTER TABLE [dbo].[Privilege] ADD  CONSTRAINT [DF_Privilege_Enabled]  DEFAULT ((1)) FOR [Enabled]