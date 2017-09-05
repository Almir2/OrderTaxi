CREATE TABLE [dbo].[Positions]
(
	[Id]				INT	IDENTITY (1, 1)		NOT NULL,
	[Name]				NVARCHAR(100)			NOT NULL,
	[IsManager]			BIT						NOT NULL,
	[PriorityId]		INT						NOT NULL,
	[TransportTypeId]	INT						NOT NULL, 

	CONSTRAINT [PK_Positions] PRIMARY KEY ([Id]),
)