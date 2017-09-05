SET IDENTITY_INSERT dbo.Locations ON

DECLARE @Locations TABLE(
	[Id]				INT				NOT NULL,
	[Name]				NVARCHAR(100)	NOT NULL,
	[Address]			NVARCHAR(150)	NULL,
	[ParentLocationId]	INT				NULL,
	[IsPOI]				BIT				NOT NULL,
	[CultureId]			INT				NOT NULL
	)
	
INSERT INTO @Locations ([Id], [Name], [Address], [ParentLocationId], [IsPOI], [CultureId]) VALUES
(1, N'Россия', NULL, NULL, 0, 12),
(2, N'Самарская область', NULL, 1, 0, 12),
(3, N'Московская область', NULL, 1, 0, 12),
(4, N'г. Самара', NULL, 2, 0, 12),
(5, N'г. Тольятти', NULL, 2, 0, 12),
(6, N'г. Москва', NULL, 3, 0, 12),
(7, N'Офис Росгосстрах', N'г. Тольятти, ул.Фрунзе, 25', 6, 1, 12),
(8, N'офис Конкурентов', N'г. Тольятти, ул. Юбилейная , 10', 6, 1, 12),
(9, N'TLT офис EPAM', N'г. Тольятти, ул.Юбилейная 31А', 6, 1, 12),
(10, N'SMR офис EPAM', N'г. Самара, ул.Мичурина, 777', 6, 1, 12),
(11, N'RZN офис EPAM', N'г. Рязань, ул.Победы, 3', 6, 1, 12),
(12, N'Ларёк Ашан', N'г. Москва, ул. Ленина, 35', 6, 1, 12),
(13, N'Офис ETOS', N'г. Тольятти, пр. 70 лет октября, 16', 6, 1, 12),
(14, N'Аэропорт "Самара"', N'г. Самара, аэропорт "Самара"', 2, 1, 12),
(15, N'Автовокзал "Аврора"', N'г. Тольятти, ул.70 Лет Октября, 3', 5, 1, 12),
(16, N'Dolor Sit Amet Moscow', N'г. Москва, пр. Строителей, 35', 6, 1, 12),
(17, N'LIPSY_SMR', N'г. Самара, ул. Мичурина, 21', 4, 1, 12),
(18, N'LIPSY_TLT', N'г. Тольятти, ул. Юбилейная, 31е', 5, 1, 12),
(19, N'LIPSY_MSK', N'г. Москва, ул. Генераторов, 6', 6, 1, 12)

MERGE INTO [Locations] AS [target]
USING @Locations AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name],
			[target].[Address] = [source].[Address],
			[target].[ParentLocationId]	= [source].[ParentLocationId],
			[target].[IsPOI] = [source].[IsPOI],
			[target].[CultureId] = [source].[CultureId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [Address], [ParentLocationId], [IsPOI], [CultureId]) 
	VALUES ([source].[Id], [source].[Name], [source].[Address], [source].[ParentLocationId], [source].[IsPOI], [source].[CultureId]);

SET IDENTITY_INSERT dbo.Locations OFF
GO