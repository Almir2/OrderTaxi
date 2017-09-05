SET IDENTITY_INSERT dbo.TransportTypes ON

DECLARE @TransportTypes TABLE(
	[Id]	INT				NOT NULL,
	[Name]	NVARCHAR(50)	NOT NULL
	)

INSERT INTO @TransportTypes ([Id], [Name]) VALUES
(1, N'Люкс'),
(2, N'Бизнес'),
(3, N'Стандарт'),
(4, N'Эконом')

MERGE INTO [TransportTypes] AS [target]
USING @TransportTypes AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name]) 
	VALUES ([source].[Id], [source].[Name]);

SET IDENTITY_INSERT dbo.TransportTypes OFF
GO