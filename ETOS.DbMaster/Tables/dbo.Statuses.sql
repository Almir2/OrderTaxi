CREATE TABLE [dbo].[Statuses]
(
	[Id]		INT IDENTITY (1, 1)	NOT NULL,
	[Sysname]	NVARCHAR(50)		NOT NULL,
	[Viewname]	NVARCHAR(50)		NOT NULL, 
	
	CONSTRAINT [PK_Statuses] PRIMARY KEY ([Id]), 
)