CREATE TABLE [dbo].[Limits]
(
	[LimitId]			INT	IDENTITY (1, 1)	NOT NULL, 
    [EmployeeId]		INT					NULL, 
    [FullPriceLimit]	FLOAT				NULL, 
    [TripCountLimit]	FLOAT				NULL,
	CONSTRAINT PK_Limits_LimitId PRIMARY KEY (LimitId),
	CONSTRAINT FK_Limits_EmployeeId FOREIGN KEY (EmployeeId)
		REFERENCES [dbo].[Employees](EmployeeId),
)