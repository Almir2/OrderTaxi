CREATE TABLE [dbo].[Quotas]
(
	[Id]					INT IDENTITY(1,1)	NOT NULL, 
	[EmployeeId]			INT					NOT NULL, 
	[RequestNumberQuota]	INT					NOT NULL, 
	[TotalPriceQuota]		DECIMAL(9, 2)		NOT NULL, 
	
	CONSTRAINT [PK_Quotas] PRIMARY KEY ([Id])
)
