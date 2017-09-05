DECLARE @Roles TABLE(
	[Id]            NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL
	)

INSERT INTO @Roles ([Id], [Name], [Discriminator]) VALUES
(N'1adm', N'Администратор', N'UserRole'),
(N'1mngr', N'Менеджер', N'UserRole'),
(N'1accnt', N'Бухгалтер', N'UserRole'),
(N'1scrt', N'Секретарь', N'UserRole'),
(N'1usr', N'Пользователь', N'UserRole'),
(N'1cntrctr', N'Подрядчик', N'UserRole')

MERGE INTO [Roles] AS [target]
USING @Roles AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name],
			[target].[Discriminator] = [source].[Discriminator]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [Discriminator]) 
	VALUES ([source].[Id], [source].[Name], [source].[Discriminator]);

GO