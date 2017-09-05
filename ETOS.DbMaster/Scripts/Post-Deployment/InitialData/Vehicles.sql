SET IDENTITY_INSERT dbo.Vehicles ON
DECLARE @Vehicles TABLE(
	[Id]			INT				NOT NULL,
	[Color]			NVARCHAR(50)	NOT NULL,
	[LicensePlate]	NVARCHAR(20)	NOT NULL,
	[Price]			DECIMAL(7, 2)	NOT NULL,
	[ModelId]		INT				NOT NULL,
	[ContractorId]	INT				NOT NULL
)
	
INSERT INTO @Vehicles ([Id], [Color], [LicensePlate], [Price], [ModelId], [ContractorId]) VALUES
(1, N'Изабелла', N'В 471 ТС 163 RUS', N'150.00', 1, 1),
(2, N'Чёрная', N'А 254 БВ 163 RUS', N'150.00', 2, 1),
(3, N'Металлик', N'У 352 НА 182 RUS', N'150.00', 2, 1),
(4, N'Мокка', N'Х 192 АУ 163 RUS', N'160.00', 3, 2),
(5, N'Синий туман', N'С 352 КС 182RUS', N'180.00', 5, 2),
(6, N'Белая', N'В 872 СТ 163 RUS', N'180.00', 16, 2),
(7, N'Игуана', N'Х 652 СТ 163 RUS', N'150.00', 2, 3),
(8, N'Папирус', N'Э 114 МО 163 RUS', N'160.00', 3, 3),
(9, N'Лайм', N'В 017 СТ 163 RUS', N'180.00', 4, 3),
(10, N'Красная', N'В 199 СТ 163 RUS', N'180.00', 4, 3)

MERGE INTO [Vehicles] AS [target]
USING @Vehicles AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Color] = [source].[Color],
			[target].[LicensePlate] = [source].[LicensePlate],
			[target].[Price] = [source].[Price],
			[target].[ModelId] = [source].[ModelId],
			[target].[ContractorId] = [source].[ContractorId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Color], [LicensePlate], [Price], [ModelId], [ContractorId]) 
	VALUES ([source].[Id], [source].[Color], [source].[LicensePlate], [source].[Price], [source].[ModelId], [source].[ContractorId]);

SET IDENTITY_INSERT dbo.Vehicles OFF
GO