CREATE TABLE [dbo].[ProvidedServices]
(
	[ContractorId]		INT				NOT NULL, 
	[TransportTypeId]	INT				NOT NULL, 
	[MinSeatsNumber]	INT				NOT NULL, 
	[MaxSeatsNumber]	INT				NOT NULL, 
	[Price]				DECIMAL(7, 2)	NOT NULL, 

	CONSTRAINT [PK_ProvidedServices] PRIMARY KEY ([ContractorId], [TransportTypeId])
)
