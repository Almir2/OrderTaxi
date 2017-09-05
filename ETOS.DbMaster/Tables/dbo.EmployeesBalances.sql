CREATE TABLE [dbo].[EmployeesBalances]
(
	[EmployeeId]	INT NOT NULL, 
	[TripsBalance]	INT NOT NULL, 
	[MoneyBalance]	INT NOT NULL,
	CONSTRAINT PK_EmployeesBalances_EmployeeId PRIMARY KEY (EmployeeId),
	CONSTRAINT FK_EmployeesBalances_EmployeeId FOREIGN KEY (EmployeeId)
		REFERENCES [dbo].[Employees](EmployeeId),
)