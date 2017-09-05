CREATE TABLE [dbo].[Permissions]
(
	[Id]				INT		NOT NULL, 
	[EmployeeId]		INT		NOT NULL, 
	[IsUser]			BIT		NOT NULL, 
	[IsSecretary]		BIT		NOT NULL, 
	[IsAccountant]		BIT		NOT NULL, 
	[IsManager]			BIT		NOT NULL, 
	[IsAdministrator]	BIT		NOT NULL, 
	
	CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id]) 
)
