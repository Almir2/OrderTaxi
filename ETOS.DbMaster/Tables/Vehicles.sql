CREATE TABLE [dbo].[Vehicles]
(
	[Id]				INT				NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Color]				NVARCHAR(50)	NOT NULL, 
	[LicensePlate]		NVARCHAR(20)	NOT NULL, 
	[Price]				DECIMAL(7, 2)	NOT NULL, 
	[ModelId]			INT				NOT NULL, 
	[ContractorId]		INT				NOT NULL,
	
)
