CREATE TABLE [dbo].[ProvidedServices]
(
	[ContractorId]			INT	IDENTITY (1, 1)	NOT NULL,
	[TransportTypeId]		INT					NOT NULL,	
	[MinimalNumberOfSeats]	INT					NOT NULL,
	[MaximalNumberOfSeats]	INT					NOT NULL,
	[Price]					FLOAT				NOT NULL,
	CONSTRAINT PK_ProvidedServices_ContractorId_TransportTypeId PRIMARY KEY (ContractorId,TransportTypeId),
	CONSTRAINT FK_ProvidedServices_ContractorId FOREIGN KEY (ContractorId)
		REFERENCES [dbo].[Contractors](ContractorId),
	CONSTRAINT FK_ProvidedServices_TransportTypeId FOREIGN KEY (TransportTypeId)
		REFERENCES [dbo].[TransportTypes](TransportTypeId),
)