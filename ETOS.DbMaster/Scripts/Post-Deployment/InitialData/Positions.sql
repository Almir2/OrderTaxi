SET IDENTITY_INSERT dbo.Positions ON

DECLARE @Positions TABLE(
	[Id]				INT				NOT NULL,
	[Name]				NVARCHAR(100)	NOT NULL,
	[PriorityId]		INT				NOT NULL,
	[IsManager]			BIT				NOT NULL,
	[TransportTypeId]	INT				NOT NULL
	)

INSERT INTO @Positions ([Id], [Name], [PriorityId], [IsManager], [TransportTypeId]) VALUES
(1, N'Менеджер', 1, 1, 1),
(2, N'Секретарь', 2, 0, 2),
(3, N'Бухгалтер', 2, 0, 2),
(4, N'Системный администратор', 3, 0, 3),
(5, N'Разработчик', 3, 0, 3),
(6, N'Плотник', 4, 0, 4)

MERGE INTO [Positions] AS [target]
USING @Positions AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name],
			[target].[PriorityId]	= [source].[PriorityId],
			[target].[IsManager]	= [source].[IsManager],
			[target].[TransportTypeId]	= [source].[TransportTypeId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [PriorityId], [IsManager], [TransportTypeId]) 
	VALUES ([source].[Id], [source].[Name], [source].[PriorityId], [source].[IsManager], [source].[TransportTypeId]);

SET IDENTITY_INSERT dbo.Positions OFF
GO