CREATE TABLE [dbo].[Feature](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](300) NULL,
	[Enabled] [bit] NOT NULL,
	[ModuleId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feature]  WITH CHECK ADD  CONSTRAINT [FK_Feature_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Feature] CHECK CONSTRAINT [FK_Feature_Module]
GO
ALTER TABLE [dbo].[Feature] ADD  CONSTRAINT [DF_Feature_Enabled]  DEFAULT ((1)) FOR [Enabled]