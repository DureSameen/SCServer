CREATE TABLE [dbo].[Edition]
(
	[Id] UniqueIdentifier NOT NULL PRIMARY KEY,
	Name nvarchar(300) not null,
	Enabled bit default 1
)
