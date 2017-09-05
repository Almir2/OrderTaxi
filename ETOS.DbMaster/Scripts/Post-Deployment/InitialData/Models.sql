SET IDENTITY_INSERT dbo.Models ON

DECLARE @Models TABLE(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR(50)	NOT NULL,
	[BrandId]	INT				NOT NULL
)
	
INSERT INTO @Models ([Id], [Name], [BrandId]) VALUES
(1, N'Kalina', 1),
(2, N'Priora', 1),
(3, N'Granta', 1),
(4, N'Vesta', 1),
(5, N'Rio', 2),
(6, N'Cerato', 2),
(7, N'Ceed', 2),
(8, N'Sportage', 2),
(9, N'Quoris', 2),
(10, N'Solaris', 3),
(11, N'Sonata', 3),
(12, N'Creta', 3),
(13, N'Almera', 4),
(14, N'Quashkai', 4),
(15, N'Rapid', 5),
(16, N'Octavia', 5),
(17, N'Logan', 6),
(18, N'Symbol', 6),
(19, N'Megane', 6),
(20, N'Megapolis', 7)

MERGE INTO [Models] AS [target]
USING @Models AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name],
			[target].[BrandId] = [source].[BrandId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [BrandId]) 
	VALUES ([source].[Id], [source].[Name], [source].[BrandId]);

SET IDENTITY_INSERT dbo.Models OFF
GO