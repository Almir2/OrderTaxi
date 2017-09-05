DECLARE @UserRoles TABLE(
	[UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL
	
	)

INSERT INTO @UserRoles ([UserId], [RoleId]) VALUES
(N'20a6e00b-401f-4ff8-bee9-29dde5f1097f', N'1accnt'),
(N'5027e93e-7e3a-4afe-8c86-c3008ce4e6ad', N'1adm'),
(N'95693098-124e-4475-b7c0-70aa6f8c72e2', N'1cntrctr'),
(N'fc01eb74-0048-462f-a270-2cbc167a054b', N'1scrt'),
(N'357d265f-e78c-4f2e-ba82-3c3c015d804d', N'1mngr'),
(N'f4c159d7-99c7-4466-a67f-e7dd7e81f518', N'1usr')

MERGE INTO [UserRoles] AS [target]
USING @UserRoles AS [source] ON [target].[UserId] = [source].[UserId] AND
								[target].[RoleId] = [source].[RoleId]
WHEN MATCHED THEN
	UPDATE
		SET	 [target].[UserId] = [source].[UserId],
			 [target].[RoleId] = [source].[RoleId]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([UserId], [RoleId]) 
	VALUES ([source].[UserId], [source].[RoleId]);

GO