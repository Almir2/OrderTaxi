CREATE TABLE [dbo].[Requests]
(
	[Id]					INT				NOT NULL	IDENTITY(1, 1)	PRIMARY KEY,
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
	[Price]					DECIMAL(9, 2)	NOT NULL,
	[StatusId]				INT				NOT NULL, 
)