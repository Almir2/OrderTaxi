SET IDENTITY_INSERT dbo.Contractors ON

DECLARE @Contractors TABLE(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR(100)	NOT NULL,
	[Phone]		NVARCHAR(16)	NOT NULL,
	[Tariff]	DECIMAL(7,2)	NOT NULL,
	[UserId]	NVARCHAR(128)	NULL	
	)
	
INSERT INTO @Contractors ([Id], [Name], [Phone],[Tariff]) VALUES
(1, N'Такси "Везёт"', N'21-34-45', 10.50),
(2, N'Такси "Разгон"', N'30-60-60', 13.50),
(3, N'Такси "Пуля"', N'78-50-35', 12.50),
(4, N'Такси "Пламя"', N'45-12-36', 11.00)

MERGE INTO [Contractors] AS [target]
USING @Contractors AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name],
			[target].[Phone] = [source].[Phone],
			[target].[Tariff]	= [source].[Tariff]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [Phone], [Tariff]) 
	VALUES ([source].[Id], [source].[Name], [source].[Phone], [source].[Tariff]);

SET IDENTITY_INSERT dbo.Contractors OFF
GO