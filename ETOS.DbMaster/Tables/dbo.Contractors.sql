CREATE TABLE [dbo].[Contractors]
(
	[ContractorId]	INT	IDENTITY (1, 1)		NOT NULL, 
    [Name]			NCHAR(150)				NOT NULL, 
    [Phone]			NCHAR(16)				NOT NULL, 
    [Tariff]		FLOAT					NOT NULL,
	CONSTRAINT PK_Contractors_ContractorId PRIMARY KEY (ContractorId),
)
