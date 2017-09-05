CREATE TABLE [dbo].[Services]
(
	[ContractorId]	INT	NOT NULL,
	[LocationId]	INT NOT NULL,
	CONSTRAINT PK_Services_ContractorId_LocationId PRIMARY KEY ([ContractorId], [LocationId]),
	CONSTRAINT FK_Services_ContractorId FOREIGN KEY (ContractorId)
		REFERENCES [dbo].[Contractors](ContractorId),
	CONSTRAINT FK_Services_LocationId FOREIGN KEY (LocationId)
		REFERENCES [dbo].[Locations](LocationId),
)