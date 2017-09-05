CREATE TABLE [dbo].[Models]
(
	[Id]		INT				NOT NULL	IDENTITY(1,1)	PRIMARY KEY, 
    [Name]		NVARCHAR(50)	NOT NULL, 
    [BrandId]	INT				NOT NULL
)
