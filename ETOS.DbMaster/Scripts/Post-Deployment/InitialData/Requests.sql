SET IDENTITY_INSERT dbo.Requests ON

DECLARE @Requests TABLE(
	[Id]					INT				NOT NULL,
	[EmployeeId]			INT				NULL,
	[CustomerId]			INT				NULL,
	[DeparturePointId]		INT				NULL,
	[DestinationPointId]	INT				NULL,
	[DepartureAddress]		NVARCHAR(150)	NULL,
	[DestinationAddress]	NVARCHAR(150)	NULL,
	[DepartureDateTime]		DATETIME		NOT NULL,
	[CreationDateTime]		DATETIME		NOT NULL	DEFAULT GETDATE(),
	[HasBaggage]			BIT				NOT NULL,
	[Comment]				NVARCHAR(200)	NULL, 
	[VehicleId]				INT				NULL,
	[Mileage]				FLOAT			NOT NULL, 
	[Price]					DECIMAL(9,2)	NOT NULL,
	[StatusId]				INT				NOT NULL
	)
INSERT INTO @Requests ([Id], [EmployeeId], [DeparturePointId], [DestinationPointId], [DepartureAddress], [DestinationAddress], 
						[DepartureDateTime], [HasBaggage], [Comment], [Mileage], [Price], [StatusId]) 
VALUES
(1, 2, 7, NULL, NULL, N'ул. Дзержинского, 45', '01.11.2016 16:00:00', 0, N'Необходимо забрать новое ПО у клиента дома', 0, 0, 1)

MERGE INTO [Requests] AS [target]
USING @Requests AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[EmployeeId] = [source].[EmployeeId],
			[target].[DeparturePointId] = [source].[DeparturePointId],
			[target].[DestinationPointId]	= [source].[DestinationPointId],
			[target].[DepartureAddress] = [source].[DepartureAddress],
			[target].[DestinationAddress] = [source].[DestinationAddress],
			[target].[DepartureDateTime]	= [source].[DepartureDateTime],
			[target].[HasBaggage] = [source].[HasBaggage],
			[target].[Comment]	= [source].[Comment],
			[target].[Mileage] = [source].[Mileage],
			[target].[Price] = [source].[Price],
			[target].[StatusId]	= [source].[StatusId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [EmployeeId], [DeparturePointId], [DestinationPointId], [DepartureAddress], [DestinationAddress], 
			[DepartureDateTime],[HasBaggage], [Comment], [Mileage], [Price], [StatusId]) 
	VALUES ([source].[Id], [source].[EmployeeId], [source].[DeparturePointId], [source].[DestinationPointId], 
			[source].[DepartureAddress], [source].[DestinationAddress], [source].[DepartureDateTime], [source].[HasBaggage], [source].[Comment], [source].[Mileage], [source].[Price], [source].[StatusId]);

SET IDENTITY_INSERT dbo.Requests OFF
GO