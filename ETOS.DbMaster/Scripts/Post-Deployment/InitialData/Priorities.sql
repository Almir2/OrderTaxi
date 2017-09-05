SET IDENTITY_INSERT dbo.Priorities ON

DECLARE @Priorities TABLE(
	[Id]			INT				NOT NULL,
	[Sysname]		NVARCHAR(50)	NOT NULL,
	[Viewname]		NVARCHAR(50)	NOT NULL
	)

INSERT INTO @Priorities ([Id], [Sysname], [Viewname]) VALUES
(1, N'Highest', N'Наивысший приоритет'),
(2, N'High', N'Высокий приоритет'),
(3, N'Normal', N'Средний приоритет'),
(4, N'Low', N'Низкий приоритет')

MERGE INTO [Priorities] AS [target]
USING @Priorities AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Sysname] = [source].[Sysname],
			[target].[Viewname] = [source].[Viewname]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Sysname], [Viewname]) 
	VALUES ([source].[Id], [source].[Sysname], [source].[Viewname]);

SET IDENTITY_INSERT dbo.Priorities OFF
GO