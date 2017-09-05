CREATE TABLE [dbo].[Customers]
(
	[Id]			INT				NOT NULL	IDENTITY(1, 1)	PRIMARY KEY, 
    [Lastname]		NVARCHAR(50)	NULL, 
    [Firstname]		NVARCHAR(50)	NOT NULL, 
    [Patronymic]	NVARCHAR(50)	NULL, 
    [Phone]			NVARCHAR(16)	NOT NULL, 
    [Email]			NVARCHAR(50)	NOT NULL, 
    [UserId]		NVARCHAR(128)	NULL
)
