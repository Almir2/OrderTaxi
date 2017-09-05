CREATE TABLE [dbo].[Routes]
(
	[Id]						INT IDENTITY(1,1)	NOT NULL, 
	[RequestId]					INT					NOT NULL, 
	[DeparturePointId]			INT					NULL, 
	[DeparturePointAddress]		NVARCHAR(150)		NULL, 
	[NextPointId]				INT					NULL, 
    
	CONSTRAINT [PK_Routes] PRIMARY KEY ([Id]) 
)
