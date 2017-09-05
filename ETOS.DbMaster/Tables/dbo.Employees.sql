CREATE TABLE [dbo].[Employees] (
	[Id]				INT				NOT NULL	IDENTITY(1, 1) PRIMARY KEY,
	[Lastname]			NVARCHAR(50)	NOT NULL,
	[Firstname]			NVARCHAR(50)	NOT NULL,
	[Patronymic]		NVARCHAR(50)	NOT NULL,
	[Phone]				NVARCHAR(16)	NOT NULL,
	[Email]				NVARCHAR(50)	NOT NULL,
	[LocationId]		INT				NOT NULL,
	[OrgstructureId]	INT				NOT NULL, 
	[PositionId]		INT				NOT NULL,
	[UserId]			NVARCHAR(128)	NOT NULL,
);

