CREATE TABLE [dbo].[Orgstructures]
(
	[Id]					INT				NOT NULL	IDENTITY(1, 1)	PRIMARY KEY, 
	[Name]					NVARCHAR(100)	NOT NULL, 
	[ParentOrgstructureId]	INT				NULL, 

)
