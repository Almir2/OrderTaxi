SET IDENTITY_INSERT dbo.Employees ON

DECLARE @Employees TABLE(
	[Id]				INT				NOT NULL,
	[Lastname]			NVARCHAR(50)	NOT NULL,
	[Firstname]			NVARCHAR(50)	NULL,
	[Patronymic]		NVARCHAR(50)	NOT NULL,
	[Phone]				NVARCHAR(16)	NOT NULL,
	[Email]				NVARCHAR(50)	NOT NULL,
	[LocationId]		INT				NOT NULL,
	[OrgstructureId]	INT				NOT NULL,
	[PositionId]		INT				NOT NULL,
	[UserId]			NVARCHAR(128)	NOT NULL
	)

INSERT INTO @Employees ([Id], [Lastname], [Firstname], [Patronymic], [Phone], [Email], [LocationId], [OrgstructureId], [PositionId], [UserId]) VALUES
(1, N'Железнова', N'Любовь', N'Викторовна', N'+72794857346', N'lubov_zheleznova@etos.sys', 8, 7, 1, N'20a6e00b-401f-4ff8-bee9-29dde5f1097f'),
(2, N'Ветров', N'Владимир', N'Сергеевич', N'+79274633766', N'vladimir_vetrov@etos.sys', 8, 7, 2, N'5027e93e-7e3a-4afe-8c86-c3008ce4e6ad'),
(3, N'Сидоров', N'Игорь', N'Степанович', N'+79875467312', N'igor_sidorov@etos.sys', 8, 8, 3, N'95693098-124e-4475-b7c0-70aa6f8c72e2'),
(4, N'Абрасимов', N'Василий', N'Владленович', N'+79763776356', N'vasiliy_abrasimov@etos.sys', 8, 8, 5, N'fc01eb74-0048-462f-a270-2cbc167a054b'),
(5, N'Волоцуев', N'Евгений', N'Петрович', N'+79794857346', N'evgeny_volotsuev@etos.sys', 8, 9, 5, N'357d265f-e78c-4f2e-ba82-3c3c015d804d'),
(6, N'Кондратьев', N'Глеб', N'Викторович', N'+79682394834', N'gleb_kondratyev@etos.sys', 8, 9, 5, N'f4c159d7-99c7-4466-a67f-e7dd7e81f518')

MERGE INTO [Employees] AS [target]
USING @Employees AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Lastname] = [source].[Lastname],
			[target].[Firstname] = [source].[Firstname],
			[target].[Patronymic] = [source].[Patronymic],
			[target].[Phone] = [source].[Phone],
			[target].[Email] = [source].[Email],
			[target].[LocationId] = [source].[LocationId],
			[target].[OrgstructureId] = [source].[OrgstructureId],
			[target].[PositionId] = [source].[PositionId],
			[target].[UserId] = [source].[UserId]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Lastname], [Firstname], [Patronymic], [Phone], [Email], [LocationId], [OrgstructureId], [PositionId], [UserId]) 
	VALUES ([source].[Id], [source].[Lastname], [source].[Firstname], [source].[Patronymic], [source].[Phone], 
			[source].[Email], [source].[LocationId],[source].[OrgstructureId], [source].[PositionId], [source].[UserId]);

SET IDENTITY_INSERT dbo.Employees OFF
GO