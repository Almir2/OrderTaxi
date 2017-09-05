CREATE TABLE [dbo].[Lifecycles]
(
	[Id]			INT IDENTITY(1,1)	NOT NULL, 
	[RequestId]		INT					NOT NULL, 
	[EmployeeId]	INT					NOT NULL, 
	[StatusId]		INT					NOT NULL,
	[EventDate]		DATETIME			NOT NULL DEFAULT GETDATE(), 
    
	CONSTRAINT [PK_Lifecycles] PRIMARY KEY ([Id]) 
)
