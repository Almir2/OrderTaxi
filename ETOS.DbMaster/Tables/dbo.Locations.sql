CREATE TABLE [dbo].[Locations]
(
	[Id]				INT	IDENTITY (1, 1)		NOT NULL,  
	[Name]				NVARCHAR(100)			NOT NULL, 
	[Address]			NVARCHAR(150)			NULL, 
	[ParentLocationId]	INT						NULL, 
	[IsPOI]				BIT						NOT NULL, 
	[CultureId]			INT						NOT NULL, 
	
	CONSTRAINT [PK_Locations] PRIMARY KEY ([Id])
)