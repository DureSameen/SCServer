CREATE TABLE [dbo].[EditionModules](
	[Id] [uniqueidentifier] NOT NULL,
    [EditionId] [uniqueidentifier] NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[ModuleId] [uniqueidentifier] NULL,
	[FeatureId] [uniqueidentifier] NULL,
	[PrivilegeId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_EditionModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EditionModules]  WITH CHECK ADD  CONSTRAINT [FK_EditionModules_Edition] FOREIGN KEY([EditionId])
REFERENCES [dbo].[Edition] ([Id])
GO

ALTER TABLE [dbo].[EditionModules] CHECK CONSTRAINT [FK_EditionModules_Edition]
GO
GO
ALTER TABLE [dbo].[EditionModules]  WITH CHECK ADD  CONSTRAINT [FK_EditionModules_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[EditionModules] CHECK CONSTRAINT [FK_EditionModules_Customer]
GO
ALTER TABLE [dbo].[EditionModules]  WITH CHECK ADD  CONSTRAINT [FK_EditionModules_Feature] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Feature] ([Id])
GO

ALTER TABLE [dbo].[EditionModules] CHECK CONSTRAINT [FK_EditionModules_Feature]
GO
ALTER TABLE [dbo].[EditionModules]  WITH CHECK ADD  CONSTRAINT [FK_EditionModules_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO

ALTER TABLE [dbo].[EditionModules] CHECK CONSTRAINT [FK_EditionModules_Module]
GO
ALTER TABLE [dbo].[EditionModules]  WITH CHECK ADD  CONSTRAINT [FK_EditionModules_Privilege] FOREIGN KEY([PrivilegeId])
REFERENCES [dbo].[Privilege] ([Id])
GO

ALTER TABLE [dbo].[EditionModules] CHECK CONSTRAINT [FK_EditionModules_Privilege]
GO
ALTER TABLE [dbo].[EditionModules] ADD  CONSTRAINT [DF_EditionModules_Enabled]  DEFAULT ((1)) FOR [Enabled]