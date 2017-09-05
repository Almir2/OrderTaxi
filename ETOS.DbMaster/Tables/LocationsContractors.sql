CREATE TABLE [dbo].[LocationsMaintenance]
(
	[ContractorId]	INT		NOT NULL, 
	[LocationId]	INT		NOT NULL, 

	CONSTRAINT [PK_LocationsMaintenance] PRIMARY KEY ([ContractorId], [LocationId]) 

)
