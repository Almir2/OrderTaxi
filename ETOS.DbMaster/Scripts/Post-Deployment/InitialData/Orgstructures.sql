SET IDENTITY_INSERT dbo.Orgstructures ON

DECLARE @Orgstructures TABLE(
	[Id]					INT				NOT NULL,
	[Name]					NVARCHAR(100)	NOT NULL,
	[ParentOrgstructureId]	INT				NULL
	)

INSERT INTO @Orgstructures ([Id], [Name], [ParentOrgstructureId]) VALUES
(1, N'Lipsum Systems Russia', NULL),
(2, N'Lipsum Systems Samara District', 1),
(3, N'LIPSY_SMR ', 2),
(4, N'LIPSY_SMR Java R&D dept.', 3),
(5, N'LIPSY_SMR .NET R&D dept.', 3),
(6, N'LIPSY_SMR BigData R&D dept.', 3),
(7, N'LIPSY_TLT', 2),
(8, N'LIPSY_TLT Java R&D dept.', 7),
(9, N'LIPSY_TLT .NET R&D dept.', 7),
(10, N'LIPSY_MSK', 1),
(11, N'LIPSY_MSK Java R&D dept.', 10),
(12, N'LIPSY_MSK .NET R&D dept.', 10),
(13, N'LIPSY_MSK Oracle R&D dept.', 10),
(14, N'LIPSY_MSK BigData R&D dept.', 10)


MERGE INTO [Orgstructures] AS [target]
USING @Orgstructures AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name],
			[target].[ParentOrgstructureId]	= [source].[ParentOrgstructureId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [ParentOrgstructureId]) 
	VALUES ([source].[Id], [source].[Name], [source].[ParentOrgstructureId]);

SET IDENTITY_INSERT dbo.Orgstructures OFF
GO