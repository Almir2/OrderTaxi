SET IDENTITY_INSERT dbo.Statuses ON

DECLARE @Statuses TABLE(
	[Id]		INT				NOT NULL,
	[Sysname]	NVARCHAR(50)	NOT NULL,
	[Viewname]	NVARCHAR(50)	NOT NULL
	)

INSERT INTO @Statuses ([Id], [Sysname], [Viewname]) VALUES
(1, N'OnApproval', N'На согласовании'),
(2, N'VehicleSelection', N'Заявка на этапе подбора автомобиля'),
(3, N'WasDeclined', N'Заявка отклонена'),
(4, N'WasCancelledByUser', N'Заявка отменена пользователем'),
(5, N'WasAccepted', N'Заявка подтверждена'),
(6, N'WasCompletedSuccessfully', N'Заявка успешно завершена'),
(7, N'WasCompletedPoorly', N'Заявка завершена неуспешно')

MERGE INTO [Statuses] AS [target]
USING @Statuses AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Sysname] = [source].[Sysname],
			[target].[Viewname] = [source].[Viewname]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Sysname], [Viewname]) 
	VALUES ([source].[Id], [source].[Sysname], [source].[Viewname]);

SET IDENTITY_INSERT dbo.Statuses OFF
GO