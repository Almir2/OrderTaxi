CREATE TABLE [dbo].[Permissions]
(
	[PermissionId]		INT IDENTITY (1, 1) NOT NULL, 
    [IsCommonUser]		BIT					NOT NULL, 
    [IsSecretary]		BIT					NOT NULL, 
    [IsAccountant]		BIT					NOT NULL, 
    [IsManager]			BIT					NOT NULL, 
    [IsAdministrator]	BIT					NOT NULL, 
    [EmployeeId]		INT					NOT NULL,
	CONSTRAINT PK_Permissions_PermissionId PRIMARY KEY (PermissionId),
	CONSTRAINT FK_Permissions_EmployeeId FOREIGN KEY (EmployeeId)
		REFERENCES [dbo].[Employees](EmployeeId),
)