SET IDENTITY_INSERT dbo.Customers ON

DECLARE @Customers TABLE(
	[Id]				INT				NOT NULL,
	[Lastname]			NVARCHAR(50)	NULL,
	[Firstname]			NVARCHAR(50)	NOT NULL,
	[Patronymic]		NVARCHAR(50)	NULL,
	[Phone]				NVARCHAR(16)	NOT NULL,
	[Email]				NVARCHAR(50)	NOT NULL,
	[UserId]			NVARCHAR(128)	NULL
	)

INSERT INTO @Customers ([Id], [Lastname], [Firstname], [Patronymic], [Phone], [Email],[UserId]) VALUES
(1, NULL, N'Олег', NULL , N'+79154912432','oleg_yakushev@gmail.com', NULL),
(2, N'Сидоров', N'Артем', N'Львович', N'+79277635721', N'sidorov_artem@gmail.com', NULL),
(3, NULL, N'Сергей', N'Степанович', N'+79395467492', N'sergey_kozlov@gmail.com', NULL),
(4, NULL, N'Оксана', N'Дмитриевна', N'+79179156591', N'oksana_halilova@gmail.com', NULL),
(5, N'Алмазов', N'Казимир', N'Викторович', N'+79062519262', N'kazimir_almazov@gmail.com', NULL),
(6, NULL, N'Жанна', NULL, N'+79652159236', N'zhanna_yurikova@gmail.com', NULL)

MERGE INTO [Customers] AS [target]
USING @Customers AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Lastname] = [source].[Lastname],
			[target].[Firstname] = [source].[Firstname],
			[target].[Patronymic] = [source].[Patronymic],
			[target].[Phone] = [source].[Phone],
			[target].[Email] = [source].[Email],
			[target].[UserId] = [source].[UserId]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Lastname], [Firstname], [Patronymic], [Phone], [Email], [UserId]) 
	VALUES ([source].[Id], [source].[Lastname], [source].[Firstname], [source].[Patronymic], [source].[Phone], [source].[Email], [source].[UserId]);

SET IDENTITY_INSERT dbo.Customers OFF
GO