CREATE TABLE [dbo].[CustomerModules](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[ModuleId] [uniqueidentifier] NULL,
	[FeatureId] [uniqueidentifier] NULL,
	[PrivilegeId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_CustomerModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerModules]  WITH CHECK ADD  CONSTRAINT [FK_CustomerModules_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[CustomerModules] CHECK CONSTRAINT [FK_CustomerModules_Customer]
GO
ALTER TABLE [dbo].[CustomerModules]  WITH CHECK ADD  CONSTRAINT [FK_CustomerModules_Feature] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Feature] ([Id])
GO

ALTER TABLE [dbo].[CustomerModules] CHECK CONSTRAINT [FK_CustomerModules_Feature]
GO
ALTER TABLE [dbo].[CustomerModules]  WITH CHECK ADD  CONSTRAINT [FK_CustomerModules_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO

ALTER TABLE [dbo].[CustomerModules] CHECK CONSTRAINT [FK_CustomerModules_Module]
GO
ALTER TABLE [dbo].[CustomerModules]  WITH CHECK ADD  CONSTRAINT [FK_CustomerModules_Privilege] FOREIGN KEY([PrivilegeId])
REFERENCES [dbo].[Privilege] ([Id])
GO

ALTER TABLE [dbo].[CustomerModules] CHECK CONSTRAINT [FK_CustomerModules_Privilege]
GO
ALTER TABLE [dbo].[CustomerModules] ADD  CONSTRAINT [DF_CustomerModules_Enabled]  DEFAULT ((1)) FOR [Enabled]